using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceItem2 : MonoBehaviour
{//앨리스가 두꺼워지는 아이템
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("Item2");
        }
    }

    IEnumerator Item2()
    {
        player.transform.localScale = new Vector3(2f, 1f, 1f);
        yield return new WaitForSeconds(3.0f);
        player.transform.localScale = new Vector3(1f, 1f, 1f);
        gameObject.SetActive(false);        //아이템 삭제(비활성화)
    }
}
