using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab1;
    public GameObject prefab2;
    public float time;
    float current = 0;
    int check;
    void Start()
    {

    }
    void Update()
    {
        check = GameObject.Find("Canvas_itemButton").GetComponent<Choose_item>().check_heartriden;
        if (check == -1)
        {
            time = 1f;
        }
        else 
        {
            time = 2f;
        }
        current += Time.deltaTime;
        copy();
    }
    void copy()
    {
        if (current >= time)
        {
            Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
            Instantiate(prefab1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
            Instantiate(prefab2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
            current = 0;
        }
    }
}
