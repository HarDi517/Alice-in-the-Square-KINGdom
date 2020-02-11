using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondMenu : MonoBehaviour
{
    public Text placeText;
    public Text stageText;
    public Text contentText;
    
    public GameObject start;

    public GameObject startSound;

    void Start()
    {
        switch (FirstMenu.stage)
        {
            case 0:
                placeText.text = "토끼 굴 서제";
                stageText.text = "Stage 1";
                contentText.text = "친구들을 따라서 나도 얼마전부터 sns를 시작했다! \n" +
                    "하지만 아직 올릴 만한 괜찮은 사진찍기가 어렵다. ㅠ\n" +
                    "ㅠ 사진 때문에 요즘 핸드폰 카메라만 쳐다보고 있다";
                break;
            case 1:
                placeText.text = "카페 가는 길";
                stageText.text = "Stage 2";
                contentText.text = "감성 넘치는 글귀가 가득한 서제에 다녀왔다. 특히\n" +
                    "‘너의 return값은 항상 1이야’ 라는 문구가 인상깊었\n" +
                    "다.이 근처에 유명한 카페가 있다고 한다! 거기로 가\n" +
                    "봐야지";
                break;
            case 2:
                placeText.text = "café HATTER";
                stageText.text = "Stage 3";
                contentText.text = "역시 유명한 카페로 가는 길은 험난하다. 힘들게 도착\n" +
                    "해도 다들 휴업이라고 하고 ㅠㅠ 포기할까 하던 중 영\n" +
                    "업 중인 café HATTER를 발견했다!고생한만큼 좋은 카페였으면 좋겠다";
                break;
            case 3:
                placeText.text = "크리켓 경기장";
                stageText.text = "Stage 4";
                contentText.text = "원래 커피가 이렇게 비싼가…? 편히 쉬고 싶었는데 \n" +
                    "의자도 딱딱하고 식탁도 낮고 불편해서 그냥 나왔다. \n" +
                    "저멀리 크리켓을 하는 사람들이 보인다. 오랜만에 운\n" +
                    "동 좀 해볼까?";
                break;
            case 4:
                placeText.text = "재판장";
                stageText.text = "Stage 5";
                contentText.text = "내가 무엇을 잘못했다는 건지 모르겠다. 다들 게임은\n" +
                    "안하고 사진만 찍길래 우리 게임은 언제 하는거냐고 \n" +
                    "약간 불평했을 뿐인데… 갑자기 날 사형시키겠다고 \n" +
                    "한다!이젠 그냥 집에 가고 싶다.";
                break;
            default:
                break;
        }
    }

    public void StartBtnClicked()
    {
        Instantiate(startSound, transform.position, Quaternion.identity);
        switch (FirstMenu.stage)
        {
            case 0:
                SceneManager.LoadScene("Stage1Scene");
                break;
            case 1:
                SceneManager.LoadScene("Stage2Scene");
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
    }
}
