using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBtn : MonoBehaviour
{
    int clickCount = 0;

    public GameObject quitPanel;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            clickCount++;
            if(!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);
        }
        else if(clickCount == 2)
        {
            Time.timeScale = 0;
            quitPanel.SetActive(true);
            // CancelInvoke("DoubleClick");
            // Application.Quit();
        }
    }

    void DoubleClick()
    {
        clickCount = 0;
    }

    public void QuitYesBtnClicked()
    {
        CancelInvoke("DoubleClick");
        Application.Quit();
    }

    public void QuitNoBtnClicked()
    {
        quitPanel.SetActive(false);
        Time.timeScale = 1;
        clickCount = 0;
    }

}
