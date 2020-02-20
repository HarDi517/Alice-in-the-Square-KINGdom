using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObst_3 : MonoBehaviour
{
    public GameObject collidedObj;
    public string collidedName = null;

    void OnTriggerEnter2D(Collider2D collision)
    {//엔드라인에 닿으면
        if (collision.CompareTag("Enemy") || collision.CompareTag("Item"))
        {//충돌한 오브젝트가 장애물(아이템)일 때

            //충돌한 장애물의 이름 찾기
            collidedObj = collision.gameObject;
            collidedName = ObjectPool_3.objectPool.getName(collidedObj);

            //오브젝트 재활용
            if (collidedName == "neon")
                ObjectPool_3.objectPool.Neon.count++;
            else if (collidedName == "vaseL")
                ObjectPool_3.objectPool.VaseL.count++;
            else if (collidedName == "vaseR")
                ObjectPool_3.objectPool.VaseR.count++;
            else if (collidedName == "catL1" || collidedName == "catL2")
                ObjectPool_3.objectPool.CatL1.count++;
            else if (collidedName == "catR")
                ObjectPool_3.objectPool.CatR.count++;
            else if (collidedName == "birdL1" || collidedName == "birdL2")
                ObjectPool_3.objectPool.BirdL1.count++;
            else if (collidedName == "birdR")
                ObjectPool_3.objectPool.BirdR.count++;
            else if (collidedName == "clockL")
                ObjectPool_3.objectPool.ClockL.count++;
            else if (collidedName == "clockR")
                ObjectPool_3.objectPool.ClockR.count++;
            else if (collidedName == "cupL")
                ObjectPool_3.objectPool.CupL.count++;
            else if (collidedName == "cupR")
                ObjectPool_3.objectPool.CupR.count++;
            else if (collidedName == "flipItem")
            {
                ObjectPool_3.objectPool.FlipItem[0].count++;
                ObjectPool_3.objectPool.MoveFlipItem();
            }
            else
                return;

            if(collidedName != null)
                ObjectPool_3.objectPool.MoveObj();
        }
    }


}
