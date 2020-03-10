using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBg : MonoBehaviour
{
    public GameObject quadGameObject;
    private Renderer quadRenderer;

    float scrollSpeed = 1f;

    void Start()
    {
        quadRenderer = quadGameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 textureOffset = new Vector2(0, -Time.time * scrollSpeed);
        quadRenderer.material.mainTextureOffset = textureOffset;
    }

}

