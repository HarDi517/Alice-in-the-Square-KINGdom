using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public Image[] creditBars;
    public Image creditImage;
    public Sprite[] creditSprites;

    public Text creditText1;
    public Text creditText2;

    string[] content1 = { "스테이지 2 BGM", "스테이지 5 BGM", "우리 이름" };
    string[] content2 = { "Song :\nPurple planet - Playful Upbeat Times\nMusic:\nhttps://www.purple-planet.com\nMusic promoted by DayDreamSound : \nhttps://youtu.be/vvybA4u9HJ4",
    "Song :\nHEMIO - Sekhmet-orchestra\nFollow Artist :\nhttps://www.youtube.com/user/FVGozak \nMusic promoted by DayDreamSound :\nhttps://youtu.be/rIHvXmMRUXE",
    "아무튼 이름들"};
    public float maxTime = 5f;
    float timeLeft;
    int i;

    void Start()
    {
        Time.timeScale = 1;
        timeLeft = maxTime;
        i = 0;
        creditImage.sprite = creditSprites[i];
        creditText1.text = content1[i];
        creditText2.text = content2[i];
    }

    private void Update()
    {
        if (i < creditBars.Length)
        {
            creditImage.sprite = creditSprites[i];
            creditText1.text = content1[i];
            creditText2.text = content2[i];
            if (timeLeft > 0)
            {
                timeLeft -= 2 * Time.deltaTime;
                creditBars[i].fillAmount = 1- timeLeft / maxTime;
            }
            else
            {
                i++;
                timeLeft = maxTime;
            }
        }
        else
        {
            SceneManager.LoadScene("Main1Scene");
        }
    }
}