using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gosmdochi1 : MonoBehaviour
{//고슴도치 이동

    public float movingSpeed = 2.5f;
    public float upSpeed = 0.8f;
    public GameObject player;
    public float distance;
    public bool inScreen = false;
    public int gosmNum;

    public AudioSource audioSource;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position.y - gameObject.transform.position.y;

        if(distance < 6f && distance > -6f)
            inScreen = true;
        else
            inScreen = false;

        if (inScreen)
            transform.Translate(movingSpeed * Time.deltaTime, upSpeed * Time.deltaTime, 0);
        else if (distance < -4f)
            MoveGosmdochi(gosmNum);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            movingSpeed *= -1;
            audioSource.time = 0;
            audioSource.Play();
        }
    }

    void MoveGosmdochi(int num)
    {
        switch (num)
        {
            case 1:
                gameObject.transform.localPosition = new Vector3(1.07f, -144.7f, 0);
                break;
            case 2:
                gameObject.transform.localPosition = new Vector3(1.07f, -155.15f, 0);
                break;
            case 3:
                gameObject.transform.localPosition = new Vector3(1.07f, -165.07f, 0);
                break;
        }
    }

}
