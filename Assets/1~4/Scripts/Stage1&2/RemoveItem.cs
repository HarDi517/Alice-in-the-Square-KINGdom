using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItem : MonoBehaviour
{
    public Animator aliceChange;

    new Renderer renderer;

    public GameObject change;

    void Start()
    {
        aliceChange = GetComponent<Animator>();
        renderer = change.GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Line")
        {
            aliceChange.SetBool("getItem1", false);
            aliceChange.SetBool("getItem2", false);
            aliceChange.SetBool("getItem3", false);
            aliceChange.SetBool("getItem4", false);
            aliceChange.SetBool("getItem5", false);
            aliceChange.SetBool("getItem6", false);
            this.gameObject.GetComponent<Player>().unBeat = false;
            StartCoroutine("Visible");
            aliceChange.SetTrigger("idle");
        }
    }

    IEnumerator Visible()
    {
        int i = 3;
        while (i < 10)
        {
            i += 1;
            float f = i / 10.0f;
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
