using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject info2;
    public GameObject story;
    public GameObject howto;
    public GameObject start;
    public GameObject level;

    public static int stage;
    public static int health = 5;

    public void Start()
    {
        health = 5;
    }

    public void InfoBtnClicked()
    {
        info2.SetActive(true);
        level.SetActive(false);
    }

    public void StoryBtnClicked()
    {
        info2.SetActive(false);
        story.SetActive(true);
    }

    public void HowtoBtnClicked()
    {
        info2.SetActive(false);
        howto.SetActive(true);
    }

    public void Close1BtnClicked()
    {
        story.SetActive(false);
        level.SetActive(true);
    }

    public void Close2BtnClicked()
    {
        howto.SetActive(false);
        level.SetActive(true);
    }

    public void EasyBtnClicked()
    {
        start.SetActive(true);
        level.SetActive(false);
        stage = 1;
    }

    public void NormalBtnClicked()
    {
        start.SetActive(true);
        level.SetActive(false);
        stage = 2;
    }

    //public void HardBtnClicked()
    //{
    //    start.SetActive(true);
    //    level.SetActive(false);
    //    health = 1;
    //}

    public void YesBtnClicked()
    {
        start.SetActive(false);
        if (stage == 1)
            SceneManager.LoadScene("Stage1Scene");
        if (stage == 2)
            SceneManager.LoadScene("Stage2Scene");
    }

    public void NoBtnClicked()
    {
        start.SetActive(false);
        level.SetActive(true);
    }
}
