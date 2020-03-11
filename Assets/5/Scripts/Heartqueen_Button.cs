using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Heartqueen_Button : MonoBehaviour
{
    public GameObject[] warn = new GameObject[3];
    public GameObject[] attack = new GameObject[3];
    public GameObject[] heartqueen = new GameObject[3];
    public Sprite heartqueen_sprites1;
    public Sprite heartqueen_sprites2;
    Vector3[] start_heart = new Vector3[3];
    int random1_heart, random2_heart;
    string[] anim = new string[3];
    void Start()
    {
        start_heart[0] = new Vector3(-1.5f, -3.8f, 0);
        start_heart[1] = new Vector3(0, -3.8f, 0);
        start_heart[2] = new Vector3(1.5f, -3.8f, 0);
        anim[0] = "leftQueen_animation";
        anim[1] = "centerQueen_animation";
        anim[2] = "rightQueen_animation";
    }
    void Update()
    {

    }
    public void Heartqueen_onClick()
    {
        StartCoroutine(warn_sec(2));
    }
    IEnumerator warn_sec(int time)
    {
        while (time > 0)
        {
            time -= 1;
            random1_heart = Random.Range(0, 3);
            random2_heart = Random.Range(0, 3);
            if (random1_heart == random2_heart)
            {
                heartqueen[random1_heart].GetComponent<Animation>().Play(anim[random1_heart]);
                warn[random1_heart].SetActive(true);
                yield return new WaitForSecondsRealtime(1f);
                warn[random1_heart].SetActive(false);
                yield return new WaitForSecondsRealtime(0.5f);
                heartqueen[random1_heart].GetComponent<SpriteRenderer>().sprite = heartqueen_sprites1;
                attack[random1_heart].SetActive(true);
                yield return new WaitForSecondsRealtime(1f);
                heartqueen[random1_heart].GetComponent<SpriteRenderer>().sprite = heartqueen_sprites2;
                attack[random1_heart].SetActive(false);
                heartqueen[random1_heart].transform.localPosition = start_heart[random1_heart];
            }
            else
            {
                heartqueen[random1_heart].GetComponent<Animation>().Play(anim[random1_heart]);
                heartqueen[random2_heart].GetComponent<Animation>().Play(anim[random2_heart]);
                warn[random1_heart].SetActive(true);
                warn[random2_heart].SetActive(true);
                yield return new WaitForSecondsRealtime(1f);
                warn[random1_heart].SetActive(false);
                warn[random2_heart].SetActive(false);
                yield return new WaitForSecondsRealtime(0.5f);
                heartqueen[random1_heart].GetComponent<SpriteRenderer>().sprite = heartqueen_sprites1;
                heartqueen[random2_heart].GetComponent<SpriteRenderer>().sprite = heartqueen_sprites1;
                attack[random1_heart].SetActive(true);
                attack[random2_heart].SetActive(true);
                yield return new WaitForSecondsRealtime(1f);
                heartqueen[random1_heart].GetComponent<SpriteRenderer>().sprite = heartqueen_sprites2;
                heartqueen[random2_heart].GetComponent<SpriteRenderer>().sprite = heartqueen_sprites2;
                attack[random1_heart].SetActive(false);
                attack[random2_heart].SetActive(false);
                heartqueen[random1_heart].transform.localPosition = start_heart[random1_heart];
                heartqueen[random2_heart].transform.localPosition = start_heart[random2_heart];
            }
        }
    }
}
