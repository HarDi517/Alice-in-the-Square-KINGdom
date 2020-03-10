using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    public GameObject clear;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            clear.SetActive(true);
            Debug.Log("stage clear!");
            //ClearStage.clearStage = FirstMenu.stage;
            ClearStage.unLock[FirstMenu.stage] = true;
        }
    }
}

