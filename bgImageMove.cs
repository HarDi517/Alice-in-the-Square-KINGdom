using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgImageMove : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Translate(0, 2.0f * Time.deltaTime, 0);
    }
}
