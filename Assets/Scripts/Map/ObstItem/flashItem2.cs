using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashItem2 : MonoBehaviour
{//깜빡이던 불빛 켜지는 아이템

    public GameObject flash;
    public flashControl flashControl;
    private IEnumerator corutine;

    void Start()
    {
        flashControl = flash.GetComponent<flashControl>();
        corutine = flashControl.FlashDelay();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(corutine);
        }
    }
}
