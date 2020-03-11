using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float wallSpeed;    //벽 움직이는 속도(상하 이동)
    float startPosition = -22.7f;
    float endPosition = 10f;

    // Update is called once per frame
    void Update()
    {
        //벽을 위로 이동
        transform.Translate(0, wallSpeed * Time.deltaTime, 0);
        if (transform.position.y >= endPosition)
        {
            transform.Translate(0, startPosition - endPosition, 0);
        }
    }
}
