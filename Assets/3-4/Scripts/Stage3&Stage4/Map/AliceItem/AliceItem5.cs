using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceItem5 : MonoBehaviour
{//앨리스가 왼쪽으로 기울어지는 아이템
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("Item5");
        }
    }

    IEnumerator Item5()
    {
        player.transform.Rotate(0, 0, 10);
        yield return new WaitForSeconds(3.0f);
        player.transform.Rotate(0, 0, -10);
        gameObject.SetActive(false);        //아이템 삭제(비활성화)
    }
}
