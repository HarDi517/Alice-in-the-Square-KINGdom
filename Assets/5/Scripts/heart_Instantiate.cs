using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class heart_Instantiate : MonoBehaviour
{
    Animation anim_heart;
    List<string> animArray_heart;
    int check;
    void Start()
    {
        anim_heart = this.GetComponent<Animation>();
        animArray_heart = new List<string>();
        AnimationArray(animArray_heart, anim_heart);
    }
    void Update()
    {
        check = GameObject.Find("Canvas_itemButton").GetComponent<Choose_item>().check_heartriden;

        if (check == 0)
        {
            this.GetComponent<Animation>().Play(animArray_heart[1]);
        }
        else if (check == 1)
        {
            this.GetComponent<Animation>().Play(animArray_heart[2]);

        }
        else if (check == -1)
        {
            Destroy(this.gameObject);
        }
    }
    void AnimationArray(List<string> animArray, Animation anim)
    {
        foreach (AnimationState state in anim)
        {
            animArray.Add(state.name);
        }
    }
}