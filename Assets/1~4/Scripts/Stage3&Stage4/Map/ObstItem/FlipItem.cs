using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipItem : MonoBehaviour
{
    GameObject player;
    AliceController playerScript;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.transform.GetComponent<AliceController>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerScript.move_method *= -1;
    }
}
