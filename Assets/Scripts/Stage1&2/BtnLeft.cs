using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnLeft : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject alice;

    public GameObject left;

    public float minX;

    public bool btnCheck;

    void Update()
    {
        if (alice)
        {
            if (btnCheck && alice.transform.position.x > minX)
            {
                alice.transform.Translate(Vector2.left * 0.05f);
            }
        }
        else
        {
            left.SetActive(false);
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
