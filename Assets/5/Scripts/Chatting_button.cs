using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chatting_button : MonoBehaviour
{
    public GameObject deadline;
    public GameObject chat;
    public Vector3 loc;
    Vector3 present_loc;
    public int check;
    void Start()
    {
        check = 1;
        present_loc = deadline.transform.localPosition;
    }
    void Update()
    {
        
    }
    public void Chatting_onClick()
    {
        check = 0;
        chat.GetComponent<chats>().time /= 3;
        deadline.transform.localPosition = loc;
        StartCoroutine(wait(6));
    }
    IEnumerator wait(int Wait)
    {
        while (Wait > 0)
        {
            Wait -= 1;
            yield return new WaitForSecondsRealtime(1f);
        }
        deadline.transform.localPosition = present_loc;
        chat.GetComponent<chats>().time *= 3;
        check = 1;
    }
}
