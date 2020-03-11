using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public GameObject scrollBar;

    float scrollPos = 0;

    float[] pos;

    int index;

    public Image[] views;

    public Sprite circleTrue;
    public Sprite circleFalse;

    int stage;
    Sprite[][] allCutScenes;
    public Sprite[] cutScenes1;
    public Sprite[] cutScenes2;
    public Sprite[] cutScenes3;
    public Sprite[] cutScenes4;
    public Sprite[] cutScenes5;
    public Sprite[] cutScenes6;
    public Button[] cutSceneBtns;

    void Start()
    {
        allCutScenes = new Sprite[6][];
        allCutScenes[0] = cutScenes1;
        allCutScenes[1] = cutScenes2;
        allCutScenes[2] = cutScenes3;
        allCutScenes[3] = cutScenes4;
        allCutScenes[4] = cutScenes5;
        allCutScenes[5] = cutScenes6;

        stage = FirstMenu.stage;
 
        for (int i = 0; i < cutSceneBtns.Length; i++)
        {
            cutSceneBtns[i].image.sprite = allCutScenes[stage][i];
        }
    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollBar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for(int i = 0; i < pos.Length; i++)
            {
                if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
                {
                    scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                    index = i;
                }
            }
        }

        for (int i = 0; i < views.Length; i++)
        {
            if (i == index)
            {
                views[i].sprite = circleTrue;
            }
            else
            {
                views[i].sprite = circleFalse;
            }
        }
    }
}
