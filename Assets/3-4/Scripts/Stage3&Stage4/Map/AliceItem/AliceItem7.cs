using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceItem7 : MonoBehaviour
{//앨리스가 투명해지는 아이템
    public GameObject player;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D playerCollider;

    void Start()
    {
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        playerCollider = player.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("Item7");
        }
    }

    IEnumerator Item7()
    {
        spriteRenderer.color = new Color32(255, 255, 255, 90);
        playerCollider.enabled = false;
        yield return new WaitForSeconds(3.0f);
        spriteRenderer.color = new Color32(255, 255, 255, 255);
        playerCollider.enabled = true;
        gameObject.SetActive(false);        //아이템 삭제(비활성화)
    }
}
