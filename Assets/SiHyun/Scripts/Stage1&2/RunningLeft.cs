using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningLeft : MonoBehaviour
{
    public int ranStart;
    public int ranSpeed;

    private void Start()
    {
        ranStart = Random.Range(0, 50);
        ranSpeed = Random.Range(1, 6);
    }

    void Update()
    {
        if (transform.position.y > (-1 * ranStart / 10))
            transform.Translate((-1 * ranSpeed / 100f), 0f, 0f);
    }
}
