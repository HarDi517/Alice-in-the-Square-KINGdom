using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;

    public float speed;

    public GameObject collisionSound;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!other.gameObject.GetComponent<Player>().unBeat)
            {
                Instantiate(collisionSound, transform.position, Quaternion.identity);
                // player damage
                FirstMenu.health -= damage;
                Player player = GameObject.Find("Player").GetComponent<Player>();
                player.StartCoroutine(player.UnBeatTime());
                //Destroy(gameObject);
            }
        }
    }
}
