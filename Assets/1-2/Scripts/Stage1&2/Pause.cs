using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Button pauseBtn;

    public Text countText;

    public GameObject pauseMenu;

    public GameObject selectSound;

    public static bool isPause;

    void Start()
    {
        isPause = false;
    }

    void Update()
    {

    }

    public IEnumerator Countdown(int seconds)
    {
        int count = seconds;
        while (count > 0)
        {
            countText.text = count.ToString("0");
            yield return new WaitForSecondsRealtime(1);
            count--;
        }
        countText.text = "";
        RestartGame();
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        isPause = false;
        return;
    }

    public void PauseButtonClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        if (isPause == false)
        {
            Time.timeScale = 0;
            isPause = true;
            pauseMenu.SetActive(true);
            return;
        }
        if (isPause == true)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void RestartButtonClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        pauseMenu.SetActive(false);
        if (FirstMenu.stage == 0)
            SceneManager.LoadScene("Stage1Scene");
        if (FirstMenu.stage == 1)
            SceneManager.LoadScene("Stage2Scene");
    }

    public void ResumeButtonClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        pauseMenu.SetActive(false);
        StartCoroutine(Countdown(3));
    }

    public void GoOutButtonClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("MasterScene");
        FirstMenu.health = 5;
    }

    public void MainBtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("MasterScene");
        FirstMenu.health = 5;
    }
}
