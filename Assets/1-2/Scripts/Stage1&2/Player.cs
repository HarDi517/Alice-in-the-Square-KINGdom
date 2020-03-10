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

    public Image[] healthImages;

    public GameObject gameOver;
    public GameObject unBeatPanel;

    public Renderer spr;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        FirstMenu.health = 5;
        Pause pause = GameObject.Find("Menu").GetComponent<Pause>();
        pause.StartCoroutine(pause.Countdown(3));
        Time.timeScale = 0;
        spr = gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {
        Vector2 pos;

        //if (FirstMenu.health <= 0)
        //{
        //    gameOver.SetActive(true);
        //    Destroy(gameObject);
        //    Time.timeScale = 0;
        //}

        if (FirstMenu.health > 0)
        {
            for (int i = 0; i < FirstMenu.health; i++)
            {
                healthImages[i].gameObject.SetActive(true);
            }
            for (int i = FirstMenu.health; i < 5; i++)
            {
                healthImages[i].gameObject.SetActive(false);
            }
        }
        if (transform.position.y > fixedY)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 10);
        }

        pos = new Vector2(transform.position.x, transform.position.y);
    }

    public IEnumerator UnBeatTime()
    {
        unBeat = true;
        int countTime = 0;
        while (countTime < 20)
        {
            if (countTime < 3)
                unBeatPanel.SetActive(true);
            else
                unBeatPanel.SetActive(false);

            //if (countTime % 2 == 0)
            //    unBeatPanel.SetActive(true);
            //else
            //    unBeatPanel.SetActive(false);

            if (countTime % 2 == 0)
                spr.material.color = new Color32(255, 255, 255, 90);
            //spriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                spr.material.color = new Color32(255, 255, 255, 100);
                //spriteRenderer.color = new Color32(255, 255, 255, 100);

            yield return new WaitForSeconds(0.1f);
            countTime++;
        }
        spr.material.color = new Color32(255, 255, 255, 255);

        //spriteRenderer.color = new Color32(255, 255, 255, 255);     //앨리스 색깔 원상복귀
        unBeatPanel.SetActive(false);
        unBeat = false;
        yield return null;
    }
}
