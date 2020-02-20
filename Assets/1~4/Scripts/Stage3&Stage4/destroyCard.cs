using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyCard : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("flexCardBorder"))
            Destroy(gameObject);
    }
}
