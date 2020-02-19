using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObst_4 : MonoBehaviour
{
    public GameObject collidedObj;
    public string collidedName = null;

    void OnTriggerEnter2D(Collider2D collision)
    {//엔드라인에 닿으면
        if (collision.CompareTag("Enemy") || collision.CompareTag("Item"))
        {//충돌한 오브젝트가 장애물(아이템)일 때

            //충돌한 장애물의 이름 찾기
            collidedObj = collision.gameObject;
            collidedName = ObjectPool_4.objectPool.getName(collidedObj);

            //오브젝트 재활용
            if (collidedName == "plantL")
                ObjectPool_4.objectPool.PlantL.count++;
            else if (collidedName == "plantR")
                ObjectPool_4.objectPool.PlantR1.count++;
            else if (collidedName == "queenL")
                ObjectPool_4.objectPool.QueenL.count++;
            else if (collidedName == "queenR" || collidedName == "catL2")
                ObjectPool_4.objectPool.QueenR.count++;
            else if (collidedName == "lionL")
                ObjectPool_4.objectPool.LionL.count++;
            else if (collidedName == "lionR" || collidedName == "birdL2")
                ObjectPool_4.objectPool.LionR.count++;
            else if (collidedName == "gosmdochi")
                ObjectPool_4.objectPool.Gosm[0].count++;
            else if (collidedName == "flamingo")
                ObjectPool_4.objectPool.Flam[0].count++;
            else if (collidedName == "card")
                ObjectPool_4.objectPool.Card[0].count++;
            else
                return;

            if (collidedName != null)
                ObjectPool_4.objectPool.MoveObst(collidedName);
        }
    }


}
