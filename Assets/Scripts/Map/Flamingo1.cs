using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamingo1 : MonoBehaviour
{
    public static float flamingoTurnSpeed = 10f;

    void Update()
    {
        transform.Rotate(0, 0, flamingoTurnSpeed * Time.deltaTime);
    }
    
}
