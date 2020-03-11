using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalUIController : MonoBehaviour
{
    public static NormalUIController instance;

    //public GameObject readyText;
    public GameObject gameOverText;
    public GameObject unBeatTimePanel;

    private void Awake()
    {
        if (NormalUIController.instance == null)
            NormalUIController.instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //readyText.SetActive(false);

        UIevent uievent = GameObject.Find("NormalUI").GetComponent<UIevent>();
        Time.timeScale = 0;
        StartCoroutine(uievent.PauseDelay(3));

        //StartCoroutine(ShowReady());    //Ready 텍스트가 3초간 깜빡이는 코루틴 함수 실행
    }

    //텍스처 3초간 깜빡거리게 하는 코루틴 함수
    //IEnumerator ShowReady()
    //{
    //    int count = 0;
    //    while (count < 3)
    //    {
    //        readyText.SetActive(true);
    //        yield return new WaitForSeconds(0.5f);

    //        readyText.SetActive(false);

    //        yield return new WaitForSeconds(0.5f);
    //        count++;
    //    }
    //    readyText.SetActive(false);
    //    yield return null;
    //}

    public void ShowGameOver()
    {
        Time.timeScale = 0; //시간 흐름 비율 0으로
        gameOverText.SetActive(true);
    }

}
