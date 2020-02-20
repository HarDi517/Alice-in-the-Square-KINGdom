using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamItem2 : MonoBehaviour
{//플라밍고의 속도가 빨라지는 아이템

    public GameObject flamingo;
    public Flamingo1 flamingoScript;
    public AudioSource flamingoBasic;
    public AudioSource flamingoFast;

    void Start()
    {
        flamingoScript = flamingo.GetComponent<Flamingo1>();
        flamingoBasic = flamingo.GetComponent<AudioSource>();
        flamingoFast = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            flamingoScript.flamingoTurnSpeed = 120f;

            if (flamingoBasic.isPlaying)
            {
                flamingoFast.Play();
                flamingoBasic.Stop();
            }
        }

    }
}
