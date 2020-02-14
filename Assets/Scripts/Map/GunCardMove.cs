using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCardMove : MonoBehaviour
{
    public float cardSpeed = 3.0f;
    public float destroyXPos = 3.0f;

    void Update()
    {
        transform.Translate(Vector2.right * cardSpeed * Time.deltaTime);
        if(transform.position.x >= destroyXPos)
        {
            Destroy(gameObject);
        }
    }
}
