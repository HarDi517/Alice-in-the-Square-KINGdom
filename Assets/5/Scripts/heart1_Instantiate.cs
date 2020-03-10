using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart1_Instantiate : MonoBehaviour
{
    int check;
    void Start()
    {
        this.GetComponent<Animation>().Play("heart2_animation");

    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heartline2")
        {
            Destroy(gameObject);
        }
    }
}
