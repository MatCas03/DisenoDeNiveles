using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//TP2 - Mateo Castares
public class PlayerHealth : MonoBehaviour
{
    public float health;
    private float lerpTimer;
    public float maxHealth = 100;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;

    public AudioSource audioVida;
    public AudioSource muerteSFX;

    public ParticleSystem particulasDMG;

    public Image BloodHealth;

    private Color bloodHealthColor;

    private float restoreDelay = 1f;
    private float timer = 0f;
    public bool Checkpointlvl9 = false;
    public bool Checkpointlvl11 = false;

    public Transform teleportPosition;
    public Transform teleportPosition2;
    public Transform respawnLvl8;
    public Transform respawnLvl9;
    public Transform respawnLvl11;

    public delegate void HealthChangedEventHandler(float currentHealth, float maxHealth);
    public event HealthChangedEventHandler HealthChanged;

    void Start()
    {
        health = maxHealth;
        bloodHealthColor = BloodHealth.color;
    }

    void Update()
    {

        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        bloodHealthColor.a = Mathf.Clamp(bloodHealthColor.a, 0, 1f);
        ChangeColor();

        timer += Time.deltaTime;

        if (timer >= restoreDelay)
        {
            RestoreHealth(1);
            timer = 0f;
        }

        if (health <= 0)
        {
            muerteSFX.Play();

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (!Checkpointlvl9 && !Checkpointlvl11)
            {
                transform.position = respawnLvl8.position;
                health = maxHealth;
            }
            else if (Checkpointlvl9 && !Checkpointlvl11)
            {
                transform.position = respawnLvl9.position;
                health = maxHealth;
            }
            else if (Checkpointlvl11)
            {
                transform.position = respawnLvl11.position;
                health = maxHealth;
            }
        }
    }

    private void ChangeColor()
    {
        BloodHealth.color = bloodHealthColor;
    }

    private void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void UpdateHealthUI()
    {
        float frontFillAmount = frontHealthBar.fillAmount;
        float backFillAmount = backHealthBar.fillAmount;
        float healthFraction = health / maxHealth;

        if (backFillAmount > healthFraction)
        {
            frontHealthBar.fillAmount = healthFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(backFillAmount, healthFraction, percentComplete);
        }

        if (frontFillAmount < healthFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = healthFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(frontFillAmount, backHealthBar.fillAmount, percentComplete);
        }

        HealthChanged?.Invoke(health, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        audioVida.Play();
        lerpTimer = 0f;
        bloodHealthColor.a += 0.1f;
        particulasDMG.Play();
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
        bloodHealthColor.a -= 0.1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        LaserTurret laserScript = other.gameObject.GetComponent<LaserTurret>();
        if (laserScript != null)
        {
            TakeDamage(10);
        }

        if (other.CompareTag("LavaFloor"))
        {
            transform.position = teleportPosition.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala-enemigo"))
        {
            TakeDamage(8);
        }
    }
}
