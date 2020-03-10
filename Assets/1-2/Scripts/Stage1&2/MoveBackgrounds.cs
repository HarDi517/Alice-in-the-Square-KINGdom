using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgrounds : MonoBehaviour
{
    public float speed;
    //private Material material;

    public float endY;
    public float startY;

    //private void Start()
    //{
    //    material = GetComponent<Renderer>().material;
    //}
    //private void Update()
    //{
    //    Vector2 newOffset = material.mainTextureOffset;
    //    newOffset.Set(0, newOffset.y - (speed * Time.deltaTime));
    //    material.mainTextureOffset = newOffset;
    //}
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y >= endY)
        {
            Vector2 pos = new Vector2(transform.position.x, startY);
            transform.position = pos;
        }
    }
}
