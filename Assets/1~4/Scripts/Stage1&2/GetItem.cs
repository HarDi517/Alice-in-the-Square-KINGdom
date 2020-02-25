using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public Animator aliceChange;
    //public Animator doorOpenLeft;
    //public Animator doorOpenRight;

    public GameObject change;

    new Renderer renderer;

    public GameObject getItemSound;

    void Start()
    {
        aliceChange = GetComponent<Animator>();
        renderer = change.GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            Instantiate(getItemSound, transform.position, Quaternion.identity);
            int itemID = other.gameObject.GetComponent<Item>().itemID;
            if (GameObject.Find("Spawner").GetComponent<Spawner>().count > 3)
            {
                GameObject[] otherItem = GameObject.FindGameObjectsWithTag("Item");
                for (int i = 0; i < otherItem.Length; i++)
                {
                    otherItem[i].GetComponent<PolygonCollider2D>().enabled = false;
                }
            }
            switch (itemID)
            {
                case 1:
                    aliceChange.SetBool("getItem1", true);
                    break;
                case 2:
                    aliceChange.SetBool("getItem2", true);

                    break;
                case 3:
                    aliceChange.SetBool("getItem3", true);
                    break;
                case 4:
                    aliceChange.SetBool("getItem4", true);
                    break;
                case 5:
                    aliceChange.SetBool("getItem5", true);
                    break;
                case 6:
                    aliceChange.SetBool("getItem6", true);
                    break;
                case 7:
                    this.gameObject.GetComponent<Player>().unBeat = true;
                    StartCoroutine("Invisible");
                    break;
                case 8:
                    DoorOpenLeft left = GameObject.Find("obstacle2_1_1").GetComponent<DoorOpenLeft>();
                    left.StartCoroutine("OpenLeft");
                    break;
                case 9:
                    DoorOpenRight right = GameObject.Find("obstacle2_1_4").GetComponent<DoorOpenRight>();
                    right.StartCoroutine("OpenRight");
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator Invisible()
    {
        int i = 10;
        while (i > 3)
        {
            i -= 1;
            float f = i / 10.0f;
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
