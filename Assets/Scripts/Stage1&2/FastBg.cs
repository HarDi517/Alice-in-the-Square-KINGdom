using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBg : MonoBehaviour
{
    public float speed;

    private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        Vector2 newOffset = material.mainTextureOffset;
        newOffset.Set(0, newOffset.y - (speed * Time.deltaTime));
        material.mainTextureOffset = newOffset;
    }
}
