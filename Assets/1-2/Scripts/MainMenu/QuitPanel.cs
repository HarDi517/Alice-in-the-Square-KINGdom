using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPanel : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }    
}
