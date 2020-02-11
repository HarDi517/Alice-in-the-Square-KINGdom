﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnRight : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject alice;
    public GameObject right;

    public float maxX;

    public bool btnCheck;

    void Update()
    {
        if (alice)
        {
            if (btnCheck && alice.transform.position.x < maxX)
            {
                alice.transform.Translate(Vector2.right * 0.05f);
            }
        }
        else
        {
            right.SetActive(false);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        btnCheck = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        btnCheck = true;
    }
}
