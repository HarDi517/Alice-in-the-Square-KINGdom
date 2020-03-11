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

    public GameObject selectSound;
    public GameObject startSound;

    void Start()
    {
        switch (FirstMenu.stage)
        {
            case 0:
                placeText.text = "토끼 굴 서재";
                stageText.text = "Stage 1";
                contentText.text = "친구들을 따라서 나도 얼마전부터 sns를 시작했다\n! 하지만 아직 올릴 만한 괜찮은 사진찍기가 어렵\n다.ㅠㅠ 사진 때문에 요즘 핸드폰 카메라만 쳐다\n보고 있다";
                break;
            case 1:
                placeText.text = "카페 가는 길";
                stageText.text = "Stage 2";
                contentText.text = "감성 넘치는 글귀가 가득한 서재에 다녀왔다. 특히 ‘너의 return값은 항상 1이야’ 라는 문구가 인상깊었다.이 근처에 유명한 카페가 있다고 한다! 거기로 가봐야지";
                break;
            case 2:
                placeText.text = "café HATTER";
                stageText.text = "Stage 3";
                contentText.text = "역시 유명한 카페로 가는 길은 험난하다. 힘들게 도착해도 다들 휴업이라고 하고 ㅠㅠ 포기할까 하던 중 영업 중인 café HATTER를 발견했다! 고생한만큼 좋은 카페였으면 좋겠다";
                break;
            case 3:
                placeText.text = "크리켓 경기장";
                stageText.text = "Stage 4";
                contentText.text = "원래 커피가 이렇게 비싼가…? 편히 쉬고 싶었는데 의자도 딱딱하고 식탁도 낮고 불편해서 그냥 나왔다. 저멀리 크리켓을 하는 사람들이 보인다. 오랜만에 운동 좀 해볼까?";
                break;
            case 4:
                placeText.text = "재판장";
                stageText.text = "Stage 5";
                contentText.text = "내가 무엇을 잘못했다는 건지 모르겠다. 다들 게임은 안하고 사진만 찍길래 우리 게임은 언제 하는거냐고 약간 불평했을 뿐인데… 갑자기 날 사형시키겠다고 한다! 이젠 그냥 집에 가고 싶다.";
                break;
            case 5:
                placeText.text = "우리 집";
                stageText.text = "엔딩";
                contentText.text = "정말 죽다 살아났다. 우리 집이 이렇게 반가울 줄이야. sns고 뭐고 이제 다 필요 없다. 일단 집에 가서 쉬어야 겠다. 근데 아까부터 누가 날 쳐다보는 것 같은데…?";
                start.SetActive(false);
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
                SceneManager.LoadScene("Stage3Scene");
                break;
            case 3:
                SceneManager.LoadScene("Stage4Scene");
                break;
            case 4:
                SceneManager.LoadScene("SampleScene");
                break;
            default:
                break;
        }
    }

    public void BackBtnClicked()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Main1Scene");
    }
}
