using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstMenu : MonoBehaviour
{
    public Button[] stages;
    public GameObject[] panels;
    public Sprite[] sprites;
    //public Image[] images;
    public GameObject clear;

    public static int health = 5;
    public static int stage = 0;
    //public static int clearStage = 0;

    public static bool howToClicked = false;

    public Sprite nullImage;

    public GameObject selectSound;

    public void Start()
    {
        health = 5;

        //if (howToClicked)
        //{
        //    stages[8].image.sprite = sprites[8];
        //    //images[8].gameObject.SetActive(true);
        //}

        for (int i = 0; i < stages.Length; i++)
        {
            //if (i > ClearStage.clearStage)
            //{
            //    stages[i].image.sprite = null;
            //    stages[i].interactable = false;
            //    panels[i].SetActive(true);
            //}
            //else if (i == ClearStage.clearStage)
            //{
            //    stages[i].image.sprite = null;
            //    stages[i].interactable = true;
            //    panels[i].SetActive(false);
            //}
            //else
            //{
            //    stages[i].image.sprite = sprites[i];
            //    stages[i].interactable = true;
            //    panels[i].SetActive(false);
            //}
            if (ClearStage.unLock[i])
            {
                stages[i].image.sprite = sprites[i];
            }
            else
            {
                stages[i].image.sprite = nullImage;
            }

            //if (i > ClearStage.clearstage)
            //{
            //    panels[i].SetActive(true);
            //}
        }
        //stages[7].interactable = true;
        //panels[7].SetActive(false);
    }

    public void CreditBtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("CreditScene");
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

    public void EndingBtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Main2Scene");
        stage = 5;
    }

    public void ChallengeBtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        //SceneManager.LoadScene("Main4Scene");
        stage = 6;
        stages[stage].image.sprite = sprites[stage];
        ClearStage.unLock[stage] = true;
    }

    public void PushmeBtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        Animator ani = clear.GetComponent<Animator>();
        stage = 7;
        for(int i = 0; i < stages.Length; i++)
        {
            //images[i].gameObject.SetActive(false);
            stages[i].gameObject.SetActive(false);
        }
        clear.SetActive(true);
        ani.Play("clear");
        //ClearStage.clearStage = 8;
        for (int i = 0; i < ClearStage.unLock.Length; i++)
        {
            ClearStage.unLock[i] = true;
        }
        //howToClicked = true;
    }

    public void HowtoBtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Main3Scene");
        stage = 8;
        ClearStage.unLock[stage] = true;
    }

    public void ClearPanelClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        Animator ani = clear.GetComponent<Animator>();
        clear.SetActive(false);
        for (int i = 0; i < stages.Length; i++)
        {
            //images[i].gameObject.SetActive(true);
            stages[i].gameObject.SetActive(true);
            stages[i].image.sprite = sprites[i];
            stages[i].interactable = true;
        }
    }
}
