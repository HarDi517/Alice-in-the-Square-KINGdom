using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gosmdochi1 : MonoBehaviour
{//고슴도치 1번 이동

    public float movingSpeed = 2.0f;
    public float upSpeed = 1.0f;
    public GameObject player;
    public float distance;
    public bool inScreen = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position.y - transform.position.y;

        if(distance < 6f)
        {
            inScreen = true;
        }
        else
        {
            inScreen = false;
        }

        if (inScreen)
        {
            transform.Translate(movingSpeed * Time.deltaTime, upSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            movingSpeed *= -1;
        }
    }

}
