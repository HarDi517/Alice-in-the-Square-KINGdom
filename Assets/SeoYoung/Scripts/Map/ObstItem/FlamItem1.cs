using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamItem1 : MonoBehaviour
{//플라밍고의 회전이 멈추는 아이템

    public GameObject flamingo;
    public Flamingo1 flamingoScript;
    public AudioSource flamingoBasic;

    void Start()
    {
        flamingoScript = flamingo.GetComponent<Flamingo1>();
        flamingoBasic = flamingo.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            flamingoScript.flamingoTurnSpeed = 0;
            flamingo.transform.rotation = Quaternion.Euler(0, 0, -90);

            if (flamingoBasic.isPlaying)
                flamingoBasic.Stop();
        }
    }
}
