using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamItem1 : MonoBehaviour
{//플라밍고의 회전이 멈추는 아이템

    public GameObject flamingo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Flamingo1.flamingoTurnSpeed = 0;
            flamingo.transform.Rotate(0, 0, -90f);
            gameObject.SetActive(false);
        }
    }
}
