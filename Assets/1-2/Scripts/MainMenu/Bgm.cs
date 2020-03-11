using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bgm : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        SceneManager.LoadScene("Main1Scene");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 7)
        {
            Destroy(gameObject);
        }
    }
}
