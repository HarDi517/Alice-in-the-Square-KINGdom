using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopLeft : MonoBehaviour
{
    public float speed;
    public float startX;
    public float endX;
    public bool direction = true;

    void Update()
    {
        if (transform.position.x >= endX)
            direction = false;
        if (transform.position.x <= startX)
            direction = true;

        //if (startX <= transform.position.x && transform.position.x <= endX && direction == true)
        //    transform.Translate(Vector2.right * speed * Time.deltaTime);
        //if (startX <= transform.position.x && transform.position.x <= endX && direction == false)
        //    transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (direction == true)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (
            direction == false)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
