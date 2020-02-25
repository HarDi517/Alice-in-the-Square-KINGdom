using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pause_resume : MonoBehaviour
{
    private GameObject pause;
    private GameObject panel;
    private int time = 3;
    void Start()
    {
        pause = GameObject.Find("Canvas").transform.Find("Pause").gameObject;
        panel = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject;
    }

    void Update()
    {
        
    }
    //하트 다 깎였을 때 pause를 누르고 continue를 누르면 실행되버림
    //해결방안 --> 하트 다 깎였을 때 pause버튼 없애버리고 다시시작이라든지 그럼 안내창이 나오게 하면 되겠다.
    public void ActivePause()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        pause.SetActive(true)
;    }
    public void ActiveContinue()
    {
        StartCoroutine(wait(time));
        panel.SetActive(false);
        pause.SetActive(true);
    }
    IEnumerator wait(int time)
    {
        while (time > 0)
        {
            time -= 1;
            yield return new WaitForSecondsRealtime(1f);
        }
        Time.timeScale = 1f;
    }

    public void RestartButtonClicked()
    {
        //Instantiate(selectSound, transform.position, Quaternion.identity);
        pause.SetActive(false);

        SceneManager.LoadScene("SampleScene");
    }

    public void GoOutButtonClicked()
    {
        //Instantiate(selectSound, transform.position, Quaternion.identity);
        pause.SetActive(false);
        SceneManager.LoadScene("MasterScene");
        FirstMenu.health = 5;
    }

    public void MainBtnClicked()
    {
        //Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("MasterScene");
        FirstMenu.health = 5;
    }

}
