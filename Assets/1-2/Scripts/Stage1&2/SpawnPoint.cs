using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject obstacle;
    public bool eatenItem = false;
    public Object obj;

    void Start()
    {
        obj = Instantiate(obstacle, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (eatenItem)
        {
            Destroy(obj);
        }
    }
}
