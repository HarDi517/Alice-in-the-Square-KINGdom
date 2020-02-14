using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamItem2 : MonoBehaviour
{//플라밍고의 속도가 빨라지는 아이템
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Flamingo1.flamingoTurnSpeed = 120f;
            gameObject.SetActive(false);
        }
    }
}
