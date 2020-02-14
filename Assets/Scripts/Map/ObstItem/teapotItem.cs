using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teapotItem : MonoBehaviour
{
    public GameObject tea;
    public static bool teaOn = true; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            teaOn = false;
            tea.SetActive(false);
        }
    }

}
