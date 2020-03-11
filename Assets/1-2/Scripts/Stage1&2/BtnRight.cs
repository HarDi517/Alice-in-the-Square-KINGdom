﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnRight : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject alice;
    public Button right;

    public float maxX;

    public bool btnCheck;

    public Vector2 direction = Vector2.right;

    void Update()
    {
        if (alice && !Pause.isPause)
        {
            if (btnCheck && alice.transform.position.x <= maxX)
            {
                alice.transform.Translate(direction * 0.05f);
            }
        }
        else
        {
            right.interactable = false;
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
