using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    public GameObject alice;
    public GameObject[] heart = new GameObject[5];
    public GameObject you_die;
    public int i = 5;
    int check;
    void Start()
    {
        alice = GameObject.Find("Alice");
        for(int i = 0; i < 5; i++)
        {
            heart[i] = GameObject.Find("heart" + (i + 1).ToString());
        }
    }

    void Update()
    {
        check = GameObject.Find("Canvas_itemButton").GetComponent<Choose_item>().check_plusheart;
        if (check == 1) 
        {
            GameObject.Find("Canvas_itemButton").GetComponent<Choose_item>().check_plusheart = 0;
            if (i < 5)
            {
                i++;
                heart[i - 1].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            heart[i - 1].GetComponent<SpriteRenderer>().enabled = false;
    //        Destroy(heart[i - 1]);
            i--;
            if (i == 0)
            {
                Time.timeScale = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            heart[i - 1].GetComponent<SpriteRenderer>().enabled = false;
            //Destroy(heart[i - 1]);
            i--;
            if (i == 0)
            {
                Time.timeScale = 0;
            }
        }
    }
}
