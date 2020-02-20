﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyObstacle : MonoBehaviour
{
    public int damage = 1;

    public GameObject collisionSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!other.gameObject.GetComponent<Player>().unBeat)
            {
                Instantiate(collisionSound, transform.position, Quaternion.identity);
                // player damage
                //other.GetComponent<Player>().health -= damage;
                FirstMenu.health -= damage;
                Player player = GameObject.Find("Player").GetComponent<Player>();
                if (FirstMenu.health > 0)
                    player.StartCoroutine(player.UnBeatTime());
                //Destroy(gameObject);
            }
        }
    }
}
