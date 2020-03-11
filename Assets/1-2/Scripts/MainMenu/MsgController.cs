using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MsgController : MonoBehaviour
{
    public int maxMsgs = 6;

    public GameObject chatPanel;
    public GameObject inputTalk;
    public GameObject aliceTalk;

    int rand = 0;
    string[] aliceTalks =
    {
        "혹시 크레딧을 발견하셨나요? 메인화면에서 앨리스의 프로필 사진을 터치해보세요♥♥",
        "<앨리스, 추락해도 괜찮아> 게임에 대해서 궁금하다면 인스타그램에 falling.alice_king 을 검색해주세요!",
        "게임이 즐거우셨다면 구글 플레이 스토어에 평점을 남겨주세요~♬♪ 감사합니당"
    };

    bool send = false;

    public GameObject selectSound;

    TouchScreenKeyboard inputField;
    public string inputMessage;

    List<Msg> messageList = new List<Msg>();

    public GameObject inputBtn;
    public GameObject googleBtn;

    void Start()
    {
        // OpenKeyboard();
    }

    void Update()
    {
        if(rand > 2)
        {
            inputBtn.SetActive(false);
            googleBtn.SetActive(true);
        }

        // if(chatBox.text != "")
        // {
        //     if(Input.GetKeyDown(KeyCode.Return))
        //     {
        //         SendMessageToChat(chatBox.text);
        //         chatBox.text = "";
        //     }
        // }
        // else
        // {
        //     if(!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
        //         chatBox.ActivateInputField();
        // }

        // if(!chatBox.isFocused)
        // {
        //     if(Input.GetKeyDown(KeyCode.Space))
        //     {
        //         SendMessageToChat("press space");
        //     }
        // }

        if(TouchScreenKeyboard.visible == false && inputField != null)
        {
            if(inputField.done)
            {
                inputMessage = inputField.text;
                // inputText.text = inputMessage;
                if(!send && inputMessage != "")
                {
                    send = true;
                    SendMessageToChat(inputMessage);
                }
                inputMessage = null;
            }
        }
    }

    public void SendMessageToChat(string text)
    {
        if(messageList.Count >= maxMsgs)
        {
            // Destroy(messageList[0].textObj.gameObject);
            // messageList.Remove(messageList[0]);
            inputBtn.SetActive(false);
            googleBtn.SetActive(true);
        }

        Msg newMsg = new Msg();
        newMsg.text=text;

        GameObject newText = Instantiate(inputTalk, chatPanel.transform);
        newMsg.textObj = newText.GetComponentInChildren<Text>();
        newMsg.textObj.text = newMsg.text;

        float height = newText.GetComponent<RectTransform>().sizeDelta.y;

        messageList.Add(newMsg);
        
        scrollChat(height);

        StartCoroutine(AliceTalk());
    }

    IEnumerator AliceTalk()
    {
        // int rand = Random.Range(0,aliceTalks.Length);
        yield return new WaitForSeconds(1f);

        if(messageList.Count >= maxMsgs)
        {
            // Destroy(messageList[0].textObj.gameObject);
            // messageList.Remove(messageList[0]);
            inputBtn.SetActive(false);
            googleBtn.SetActive(true);
        }

        Msg newMsg = new Msg();
        newMsg.text=aliceTalks[rand];
        rand++;
        GameObject newText = Instantiate(aliceTalk, chatPanel.transform);
        newMsg.textObj = newText.GetComponentInChildren<Text>();
        newMsg.textObj.text = newMsg.text;

        float height = newText.GetComponent<RectTransform>().sizeDelta.y;

        messageList.Add(newMsg);

        scrollChat(height);
    }

    void scrollChat(float height)
    {
        GameObject[] chats = GameObject.FindGameObjectsWithTag("Chat");

        for(int i=0; i < chats.Length; i++)
        {
            float currentX = chats[i].GetComponent<RectTransform>().localPosition.x;
            float currentY = chats[i].GetComponent<RectTransform>().localPosition.y;
            RectTransform rt = chats[i].GetComponent<RectTransform>();
            rt.localPosition = new Vector3(currentX, currentY + height + 250, 0);
        }

        // for(int i = 0; i < chatUp.Length; i++)
        // {
        //         chatUp[i].GetComponent<ChatUp>().StartCoroutine(chatUp[i].ScrollChat());
        // }

        // chatPanel.GetComponentsInChildren<ChatUp>().StartCoroutine(ChatUp.ScrollChat);
    }

    public void BackBtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Main1Scene");
    }

    public void MessageImgBtnClicked()
    {
        send = false;
        OpenKeyboard();
    }

    public void GoogleImgBtnClicked()
    {
        Application.OpenURL("https://play.google.com/store/apps");
    }

    public void OpenKeyboard()
    {
        inputField = TouchScreenKeyboard.Open("",TouchScreenKeyboardType.Default);
    }

}

public class Msg
{
    public string text;
    public Text textObj;
}