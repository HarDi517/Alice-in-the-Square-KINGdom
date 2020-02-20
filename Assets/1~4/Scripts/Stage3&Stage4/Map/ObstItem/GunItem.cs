using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour
{
    public GameObject moneyPrefab;      //복제할 카드 오브젝트
    public Transform gunPos;            //카드 발사 위치(flex 건 위치)
    public Quaternion cardRotation = Quaternion.identity;
    public GameObject io_cardGun;        //장애물 부모

    public int gunNum;

    public float curDelay = 0;
    public float fireDelay = 0.3f;             //카드 발사 딜레이 시간
    private bool fireState;             //카드 발사 제어

    // Start is called before the first frame update
    void Start()
    {
        fireState = false;
        cardRotation.eulerAngles = new Vector3(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        curDelay += Time.deltaTime;
        gunFire();

        if (gunPos.position.y > 2.0f)
            fireState = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fireState = true;
        }
    }

    private void gunFire()
    {
        if (curDelay < fireDelay)
            return;

        if (fireState)
        {
            GameObject card = Instantiate(moneyPrefab, gunPos.position + new Vector3(0.2f, 0), Quaternion.identity, io_cardGun.transform) as GameObject;
            Rigidbody2D rigid = card.GetComponent<Rigidbody2D>();
            if (gunNum == 2)
            {
                card.transform.rotation = Quaternion.Euler(0, 0, 90);
                rigid.AddForce(Vector2.left * 3, ForceMode2D.Impulse);
            }
            else
            {
                card.transform.rotation = Quaternion.Euler(0, 0, -90);
                rigid.AddForce(Vector2.right * 3, ForceMode2D.Impulse);
            }

            curDelay = 0;
        }
    }


}
