using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdMenu : MonoBehaviour
{
    public Text placeText;
    public Text stageText;
    public Text contentText;

    void Start()
    {
        placeText.text = "게임 방법";
        stageText.text = "게임 방법";
        contentText.text = "앨리스를 무사히 집으로 돌려보내는 방법을 알려드\n" +
            "립니다! 장애물을 피하고, 아이템을 잘 획득해 보세요\n" +
            "! 앨리스는 과연 집에 갈 수 있을까요?";
    }
}
