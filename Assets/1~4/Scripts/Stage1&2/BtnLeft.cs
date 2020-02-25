using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnLeft : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject alice;
    public Button left;

    public float minX;

    public bool btnCheck;

    void Update()
    {
        if (alice && !Pause.isPause)
        {
            if (btnCheck && alice.transform.position.x >= minX)
            {
                alice.transform.Translate(Vector2.left * 0.05f);
            }
        }
        else
        {
            left.interactable = false;
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
