using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenRight : MonoBehaviour
{
    public Animator right;

    public GameObject doorSound;

    void Start()
    {
        right = GetComponent<Animator>();
    }

    IEnumerator OpenRight()
    {
        right.SetTrigger("openDoor_2");
        Instantiate(doorSound, transform.position, Quaternion.identity);
        yield return null;
    }
}
