using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class chats_instantiate : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[9];
    public GameObject[] buttons = new GameObject[2];
    string[] name = new string[9];
    string[] chatt = {"지금 생방송이에요?","세상 참 흉흉하여라","속인주의 속지주의 적용 안해요?", "와 저걸 피하네",
        "여왕님한테 사진 그만 찍자고 한 패기 ㄷ","사진\'만\'찍은 건 문제라고 생각함","앨리스! 항소하자!","아 이건 팝콘각인데",
        "여왕님 머리커요!","아니 근데 사진으로 꼽줬다고 바로 사형이라고?","설마 진짜로 사형할까","한번만 봐주자~",
        "~(^0^~)(~^0^)~귀엽죠?","스겜합시다~~~~~","재판 생중계는 처음 봄","인투디언노운 불러주세요","크리켓 고슴도치들 졸귀탱",
        "여왕님 사자후 봤음?","기획은 my**i_98","코더는 s**iririring","코더는 d**bfxm","코더는 ye**wo","그래픽은 ye**wo",
        "이정도 사악함이면 미니언들이 보스로 모시겠는데","cafe HATTER 아아가 7천원인 거기?" };
    Button button;
    GameObject chat;
    private int random, random1;
    public float time;
    int i;
    public string start_idx;
    int check1, check2;
    int check;

    //animation
    Animation anim;
    List<string> animArray;

    void Start()
    {
        name[0] = "kkk_**aticia";
        name[1] = "ka**er0220";
        name[2] = "mingu**angul";
        name[3] = "ye1two";
        name[4] = "notandor._.slimee";
        name[5] = "s**iririring";
        name[6] = "d**bfxm";
        name[7] = "my**i_98";
        name[8] = "Cos**12";

        buttons[0] = GameObject.Find("Canvas_itemButton").transform.Find("itemButton1_2").gameObject;
        buttons[1] = GameObject.Find("Canvas_itemButton").transform.Find("itemButton2_2").gameObject;
        chat = GameObject.Find("Chatting");
        i = chat.GetComponent<chats>().i;
        time = 1f;
        random = Random.Range(0, 9);
        this.transform.Find("Image").GetComponent<Image>().sprite = sprites[random];
        this.transform.Find("Name_Ins").GetComponent<Text>().text = name[random];
        random1 = Random.Range(0, 25);
        this.transform.Find("Chat_Ins").GetComponent<Text>().text = chatt[random1];
        check = 1;
        //animation
        //anim = this.GetComponent<Animation>();
        //animArray = new List<string>();
        //AnimationArray(animArray, anim);
    }
    void AnimationArray(List<string> animArray, Animation anim)
    {
        foreach (AnimationState state in anim)
        {
            animArray.Add(state.name);
        }
    }
    void Update()
    {
        check = GameObject.Find("Canvas_itemButton").GetComponent<Choose_item>().check_chat;
        if (check == 0)
        {
            time = 1f;
            transform.position = new Vector3(transform.position.x, transform.position.y + time * Time.deltaTime, transform.position.z);
        }
        else if (check == 1)
        {
            time = 3f;
            transform.position = new Vector3(transform.position.x, transform.position.y + time * Time.deltaTime, transform.position.z);
        }
        //if (buttons[0].activeSelf == true || buttons[1].activeSelf == true) 
        //{
        //    check1 = buttons[0].transform.parent.gameObject.GetComponent<Choose_item>().check;
        //    if (check1 == 0)
        //    {
        //        time = 3f;
        //    }
        //    else if (check1 == 1)
        //    {
        //        time = 1f;
        //    }
        //if (buttons[1].activeSelf == true)
        //{
        //    check2 = buttons[1].transform.parent.GetComponent<Choose_item>().check;
        //    if (check2 == 0)
        //    {
        //        time = 3f;
        //    }
        //    else if (check2 == 1)
        //    {
        //        time = 1f;
        //    }
        //}
        //}
        //else if (buttons[1].activeSelf == true)
        //{
        //    check2 = buttons[1].transform.parent.GetComponent<Choose_item>().check;
        //    if (check2 == 0)
        //    {
        //        time = 3f;
        //    }
        //    else if (check2 == 1)
        //    {
        //        time = 1f;
        //    }
        //}
        //transform.position = new Vector3(transform.position.x, transform.position.y + time * Time.deltaTime, transform.position.z);
        transform.name = i.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Deadline")
        {
            Destroy(gameObject);
            start_idx = gameObject.name;
        }
    }
}
