using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID;
    public float speed;

    public Sprite[] itemSprites;

    private void Start()
    {
        int rand = Random.Range(0, 2);
        if (gameObject.CompareTag("Item"))
            gameObject.GetComponent<SpriteRenderer>().sprite = itemSprites[rand];
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
