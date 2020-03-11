using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPoint : MonoBehaviour
{
    public GameObject heart;

    void Start()
    {
        Instantiate(heart, transform.position, Quaternion.identity);
    }
}
