using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstMenu : MonoBehaviour
{
    public Button[] stages;

    public static int health = 5;
    public static int stage = 0;
    public static int clearStage = 0;

    public GameObject selectSound;

    public void Start()
    {
        health = 5;
        //for(int i = 0; i < clearStage + 1; i++)
        //{
        //    stages[i].interactable = true;
        //}

        //for (int i = clearStage + 1; i < stages.Length - 1; i++)
        //{
        //    stages[i].interactable = false;
        //}
    }

    public void Stage1BtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Main2Scene");
        stage = 0;
    }

    public void Stage2BtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Main2Scene");
        stage = 1;
    }

    public void Stage3BtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Main2Scene");
        stage = 2;
    }

    public void Stage4BtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Main2Scene");
        stage = 3;
    }

    public void Stage5BtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Main2Scene");
        stage = 4;
    }

    public void ChallengeBtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Main4Scene");
        stage = 5;
    }

    public void HowtoBtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Main3Scene");
        stage = 6;
    }
}
