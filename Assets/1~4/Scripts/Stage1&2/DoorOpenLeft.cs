using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenLeft : MonoBehaviour
{
    public Animator left;

    public GameObject doorSound;

    void Start()
    {
        left = GetComponent<Animator>();
    }

     IEnumerator OpenLeft()
    {
        left.SetTrigger("openDoor_1");
        Instantiate(doorSound, transform.position, Quaternion.identity);
        yield return null;
    }
}
