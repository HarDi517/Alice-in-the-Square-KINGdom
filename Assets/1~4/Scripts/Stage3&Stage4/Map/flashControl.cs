using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashControl : MonoBehaviour
{//스타트라인에 부딪히면 불빛 깜빡이기

    public PolygonCollider2D flashCollider;
    public SpriteRenderer flashSprite;

    void Start()
    {
        flashCollider = gameObject.GetComponent<PolygonCollider2D>();
        flashSprite = gameObject.GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StartLine"))
            StartCoroutine(FlashDelay());
    }

    public IEnumerator FlashDelay()
    {
        int count = 0;
        while (count < 100)
        {
            flashCollider.enabled = false;
            flashSprite.color = new Color32(255, 255, 255, 0);
            yield return new WaitForSeconds(0.6f);

            flashCollider.enabled = true;
            flashSprite.color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.6f);
            count++;
        }

    }
}
