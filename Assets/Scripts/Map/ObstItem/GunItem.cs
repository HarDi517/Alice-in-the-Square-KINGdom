using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour
{
    public GameObject moneyPrefab;      //복제할 카드 오브젝트
    public Transform gunPos;            //카드 발사 위치(flex 건 위치)
    public Quaternion cardRotation = Quaternion.identity;
    public float fireDelay = 0.2f;             //카드 발사 딜레이 시간
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
        gunFire();
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
        if (fireState)
        {
            StartCoroutine(FireCycleControl());
            Instantiate(moneyPrefab, gunPos.position, cardRotation);
        }
    }

    IEnumerator FireCycleControl()
    {
        fireState = false;
        yield return new WaitForSeconds(fireDelay);
        fireState = true;
    }

}
