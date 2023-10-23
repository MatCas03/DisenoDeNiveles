using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public float waitTime = 5f;

    void Start()
    {
        StartCoroutine(Wait());
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("TestLevel");
        }
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene("TestLevel");
    }


}
