using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class button_right_ctrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float speed;
    public GameObject alice;
    int check;
    void Start()
    {
        alice = GameObject.Find("Alice");
    }
    void Update()
    {
        check = GameObject.Find("Canvas_itemButton").GetComponent<Choose_item>().check_stop;
        if (check == 0)
        {
            alice.transform.position = new Vector3(0f, 3f, -9.5f);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (check == 1)
        {
            alice.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed * Time.deltaTime;
        }
        else if (check == 0)
        {
            alice.GetComponent<Rigidbody2D>().velocity = Vector2.right * 0 * Time.deltaTime;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        alice.GetComponent<Rigidbody2D>().velocity = Vector2.right * 0 * Time.deltaTime;
    }
}
