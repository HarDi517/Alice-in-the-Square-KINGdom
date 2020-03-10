using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart_queen : MonoBehaviour
{
    public GameObject warn;
    public GameObject attack;
    public GameObject heartqueen;
    public string queenname;
    public float x, y, z;
    int check;
    void Start()
    {
        heartqueen = this.transform.Find(queenname).gameObject;
        warn = heartqueen.transform.Find("warning").gameObject;
        attack = heartqueen.transform.Find("attack").gameObject;
        check = 0;
    }

    void Update()
    {
        if (check == 1)
        {
            heartqueen.GetComponent<Rigidbody2D>().velocity = Vector2.up * 1f;
        }
        if (heartqueen.transform.localPosition.y >= -1.14 || check == 2)
        {
            check = 2;
            heartqueen.GetComponent<Rigidbody2D>().velocity = Vector2.up * 0f;
            StartCoroutine(warn_sec());
            StopCoroutine(warn_sec());
        }
    }
    IEnumerator warn_sec()
    {
        warn.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        warn.SetActive(false);
        yield return new WaitForSecondsRealtime(2f);
        attack.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        attack.SetActive(false);
        heartqueen.transform.localPosition = new Vector3(x, y, z);
        check = 0;
    }
    public void click_button()
    {
        check = 1;
    }
}
