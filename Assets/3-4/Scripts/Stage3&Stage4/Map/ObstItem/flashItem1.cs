using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashItem1 : MonoBehaviour
{//깜빡이던 불빛 꺼지는 아이템

    public GameObject flash;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            flash.SetActive(false);
        }
    }
}
