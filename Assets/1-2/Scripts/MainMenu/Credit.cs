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

    string main_credit = "Dimension Bucket - The Lobster Quadrille \n" +
        "License: Creative Commons 0 (CC0 1.0) \n" +
        "(https://creativecommons.org/publicdomain/zero/1.0/legalcode) \n\n";
    string stage1_credit = "Rafael Krux - Jungle Mission (https://freepd.com/) \n" +
        "License: Creative Commons 0 (CC0 1.0) \n" +
        "(https://creativecommons.org/publicdomain/zero/1.0/legalcode) \n\n";
    string stage2_credit = "Purple planet - Playful Upbeat Times \n" +
        "Promoted by DayDreamSound (https://youtu.be/vvybA4u9HJ4) \n\n";
    string stage3_credit = "Alexander Nakarada - Foam Rubber \n" +
        "License: Creative Commons 0 (CC0 1.0) \n" +
        "(https://creativecommons.org/publicdomain/zero/1.0/legalcode) \n\n";
    string stage4_credit = "Rafael Krux - Monsters in Hotel \n" +
        "License: Creative Commons 0 (CC0 1.0) \n" +
        "(https://creativecommons.org/publicdomain/zero/1.0/legalcode) \n\n";
    string stage5_credit = "\"HEMIO - Sekhmet-orchestra\" \n" +
        "Promoted by DayDreamSound (https://youtu.be/rIHvXmMRUXE) \n";

    string[] content1 = { "메인화면 BGM \n\n\n\n\n스테이지1 BGM \n\n\n\n\n스테이지2 BGM",
        "스테이지3 BGM \n\n\n\n\n스테이지4 BGM \n\n\n\n\n스테이지5 BGM", "제작" };

    string[] content2 = new string[3];

    public float maxTime = 5f;
    float timeLeft;
    int i;

    void Awake()
    {
        content2[0] = main_credit + "\n\n\n" + stage1_credit + "\n\n\n" + stage2_credit + "\n";
        content2[1] = stage3_credit + "\n\n\n" + stage4_credit + "\n\n\n" + stage5_credit + "\n";
        content2[2] = "PM & 그래픽 : 이예원\n\n" +
            "기획 : 임현지 \n\n코더 : 김시현(UI, Stage1, Stage2)\n" +
            "\t   이서영(Stage3, Stage4), 이예원(Stage5)\n";
    }

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
                creditBars[i].fillAmount = 1 - timeLeft / maxTime;
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