using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ForthMenu : MonoBehaviour
{
    public Text placeText;
    public Text stageText;
    public Text contentText;

    public GameObject start;

    public GameObject selectSound;
    public GameObject startSound;

    void Start()
    {
        placeText.text = "끝나지 않는 재판장";
        stageText.text = "도전 모드";
        contentText.text = "이 세상엔 참 이상한 사람들이 많다. 사형당할 뻔하다가 겨우겨우 살아 돌아왔는데 끝이 없는 재판장을 원하는 사람들이 있다고 한다. 정말…이상한 사람들이 많다";
    }

    public void StartBtnClicked()
    {
        Instantiate(startSound, transform.position, Quaternion.identity);

    }

    public void BackBtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Main1Scene");
    }

}
