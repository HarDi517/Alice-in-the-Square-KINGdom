using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public GameObject sound;
    private bool soundOn = false;

    void Update()
    {
        if(transform.position.y >= -5 && !soundOn)
        {
            soundOn = true;
            Instantiate(sound, transform.position, Quaternion.identity);
        }

        if(transform.position.y > 5 && soundOn)
        {
            soundOn = false;
//            Destroy(sound);
        }
    }
}
