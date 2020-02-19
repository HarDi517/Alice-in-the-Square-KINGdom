using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    float screenSpeed = 3.34f;       //맵 이동 속도
    
    void Update()
    {
        //맵(오브젝트) 위로 이동
        gameObject.transform.Translate(0, screenSpeed * Time.deltaTime, 0);
    }
}
