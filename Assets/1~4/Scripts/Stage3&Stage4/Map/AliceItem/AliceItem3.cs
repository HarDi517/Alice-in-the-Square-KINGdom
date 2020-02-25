using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceItem3 : MonoBehaviour
{//앨리스가 짧아지는 아이템
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("Item3");
        }
    }

    IEnumerator Item3()
    {
        player.transform.localScale = new Vector3(1f, 0.5f, 1f);
        yield return new WaitForSeconds(3.0f);
        player.transform.localScale = new Vector3(1f, 1f, 1f);
        gameObject.SetActive(false);        //아이템 삭제(비활성화)
    }
}
