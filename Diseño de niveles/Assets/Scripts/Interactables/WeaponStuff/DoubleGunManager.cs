using System.Collections;
using UnityEngine;

public class DoubleGunManager : MonoBehaviour
{
    public static DoubleGunManager Instance { get; private set; }

    [SerializeField] private float shootInterval = 3f;
    private float timeSinceLastShot;
    private bool canShoot = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    public bool CanShoot()
    {
        return canShoot;
    }

    public void StartCooldown()
    {
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootInterval);
        canShoot = true;
    }
}
