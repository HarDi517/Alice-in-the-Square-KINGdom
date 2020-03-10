using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Follow : MonoBehaviour
{
    public Text followerText;

    public Button followBtn;
    public Sprite follow;
    public Sprite unFollow;

    public void Update()
    {
        if (ClearStage.following)
        {
            followerText.text = "4\n팔로워";
            followBtn.image.sprite = unFollow;
            followBtn.GetComponentInChildren<Text>().text = "팔로우";
        }
        else
        {
            followerText.text = "5\n팔로워";
            followBtn.image.sprite = follow;
            followBtn.GetComponentInChildren<Text>().text = "팔로잉";
        }
    }

    public void FollowBtnClicked()
    {
        if (ClearStage.following)
        {
            ClearStage.following = false;
        }
        else
        {
            ClearStage.following = true;
        }
    }

    public void MessageBtnClicked()
    {
        SceneManager.LoadScene("MessageScene");
    }

}
