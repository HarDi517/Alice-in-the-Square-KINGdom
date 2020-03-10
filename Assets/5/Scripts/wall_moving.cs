using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_moving : MonoBehaviour
{
    public const float speed = 0.5f;
    Material Wall;
    void Start()
    {
        Wall = GetComponent<Renderer>().material;
    }

    void Update()
    {
        Vector2 newoffset = Wall.mainTextureOffset;
        newoffset.Set(0, newoffset.y - speed * Time.deltaTime);
        Wall.mainTextureOffset = newoffset;
    }
}
