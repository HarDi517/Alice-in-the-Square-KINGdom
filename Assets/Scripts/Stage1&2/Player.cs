using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector2 alicePos;

    public float fixedY;

    public bool unBeat = false;

    public Text healthDisplay;

    public GameObject gameOver;
    public GameObject unBeatPanel;

    public Renderer spr;

    private void Awake()
    {
        FirstMenu.health = 5;    
    }

    private void Start()
    {
        Pause pause = GameObject.Find("Menu").GetComponent<Pause>();
        pause.StartCoroutine(pause.Countdown(3));
        Time.timeScale = 0;
        spr = gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {
        Vector2 pos;

        string heart = "";
        for (int i = 0; i < FirstMenu.health; i++)
        {
            heart += "♥";
        }
        healthDisplay.text = heart;

        //if (FirstMenu.health <= 0)
        //{
        //    gameOver.SetActive(true);
        //    Destroy(gameObject);
        //}

        if (transform.position.y > fixedY)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 10);
        }

        pos = new Vector2(transform.position.x, transform.position.y);
    }

    public IEnumerator UnBeatTime()
    {
        int countTime = 0;
        while (countTime < 10)
        {
            if (countTime % 2 == 0)
                unBeatPanel.SetActive(true);
            else
                unBeatPanel.SetActive(false);

            yield return new WaitForSeconds(0.1f);
            countTime++;
        }

        unBeatPanel.SetActive(false);
        unBeat = false;
        yield return null;
    }
}
