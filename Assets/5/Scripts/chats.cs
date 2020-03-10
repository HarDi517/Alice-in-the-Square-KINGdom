using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chats : MonoBehaviour
{
    public GameObject prefab;
    public float time;
    public int i;
    float current = 0;
    void Start()
    {
        i = 0;
        time = 47f * Time.deltaTime;
    }
    void Update()
    {
        current += Time.deltaTime;
        copy();
    }
    void copy()
    {
        if (current >= time)
        {
            Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
            current = 0;
        }
    }
}
