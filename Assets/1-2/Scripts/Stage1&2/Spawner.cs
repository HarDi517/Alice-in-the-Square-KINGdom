using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;
    public int count = 0;

    public GameObject gameClear;
    public GameObject alice;

    public int clearStage;

    private void Start()
    {
        startTimeBtwSpawn = 3.34f;
    }

    private void Update()
    {
        if(timeBtwSpawn <= 0)
        {
            if (count >= obstaclePatterns.Length)
            {
                gameClear.SetActive(true);
                Destroy(alice);
                count = 0;
                //ClearStage.clearStage = FirstMenu.stage;
                ClearStage.unLock[FirstMenu.stage] = true;
            }

            Instantiate(obstaclePatterns[count++], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
