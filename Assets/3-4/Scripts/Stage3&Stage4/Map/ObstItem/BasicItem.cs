using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : MonoBehaviour
{//아이템 2개 중 한 번에 한 개만 먹을 수 있도록
    
    public GameObject linkedItem;       //인스펙터 창에서 직접 넣어주기
    public PolygonCollider2D linkedCollider;

    void Start()
    {
        if (linkedItem)
            linkedCollider = linkedItem.GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {//아이템 먹으면 옆 아이템 먹기 불가
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if (linkedCollider)
                linkedCollider.enabled = false;
        }
    }

}
