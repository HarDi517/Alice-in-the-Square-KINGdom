using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIevent : MonoBehaviour
{
    private bool pauseOn = false; //true일 때 일시정지 활성화
    private GameObject normalPanel;
    private GameObject pausePanel;
    public Text countText;

    void Awake()
    {
        normalPanel = GameObject.Find("Canvas").transform.Find("NormalUI").gameObject;
        pausePanel = GameObject.Find("Canvas").transform.Find("PauseUI").gameObject;
    }
    
    void Start()
    {
        pausePanel.SetActive(false);
        normalPanel.SetActive(true);
    }

    public void ActivePauseBt()
    {//일시정지 버튼 처리 함수
        if (!pauseOn)
        {//일시정지 중이 아니면 일시정지
            Time.timeScale = 0; //시간 흐름 비율 0으로
            pausePanel.SetActive(true);
            normalPanel.SetActive(false);
        }

        else
        {
            pausePanel.SetActive(false);
            normalPanel.SetActive(true);
            StartCoroutine(PauseDelay(3));
        }

        pauseOn = !pauseOn; //버튼 활성화 상태 반전
    }

    public void RetryBt()
    {
        Debug.Log("게임 재시작");
        Time.timeScale = 1.0f;
        if (FirstMenu.stage == 2)
            SceneManager.LoadScene("Stage3Scene");    //Stage4 씬 다시 로드
        if (FirstMenu.stage == 3)
            SceneManager.LoadScene("Stage4Scene");
    }

    public void GotoMainBt()
    {
        SceneManager.LoadScene("MasterScene");
        Debug.Log("메인화면으로 이동");
    }

    public IEnumerator PauseDelay(int seconds)
    {
        //3초 딜레이, 3초 카운트 넣기
        int count = seconds;
        
        while (count > 0)
        {
            countText.text = count.ToString("0");
            count--;
            yield return new WaitForSecondsRealtime(1.0f);
        }

        countText.text = "";
        Time.timeScale = 1.0f; //시간 흐름 비율 원상태로
        yield return null;
    }
    
 
}
