using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamItem3 : MonoBehaviour
{//플라밍고2 목 꺾이는 아이템
    
    public Animator item;
    public AudioSource flamingoNeck;

    void Start()
    {
        flamingoNeck = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            item.SetTrigger("item");
            if(!flamingoNeck.isPlaying)
                flamingoNeck.Play();
        }
    }
}
