using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public float ScreenSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //아래로 화면 이동
        transform.Translate(Vector2.down * ScreenSpeed * Time.deltaTime);
    }
}
