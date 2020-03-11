using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCardMove : MonoBehaviour
{
    public float cardSpeed = 3.0f;
    public float destroyXPos = 3.0f;

    void Update()
    {
        gameObject.transform.Translate(Vector3.right * cardSpeed * Time.deltaTime);
        if(gameObject.transform.position.x >= destroyXPos)
        {
            Destroy(gameObject);
        }
    }
}
