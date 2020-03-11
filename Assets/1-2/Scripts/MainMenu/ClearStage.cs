using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStage : MonoBehaviour
{
    //public static int clearStage = 0;
    public static bool following = true;

    public static bool[] unLock = new bool[9];

    private void Start()
    {
        for (int i = 0; i < unLock.Length; i++)
            unLock[i] = false;
    }
}
