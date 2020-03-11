using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
public class Choose_item : MonoBehaviour
{
    //Buttons
    //chatting_button
    public GameObject deadline;
    public GameObject chat;
    public Vector3 loc;
    Vector3 present_loc;
    public int check_chat;
    //heartqueen_button
    public GameObject[] warn = new GameObject[3];
    public GameObject[] attack = new GameObject[3];
    public GameObject[] heartqueen = new GameObject[3];
    public Sprite heartqueen_sprites1;
    public Sprite heartqueen_sprites2;
    Vector3[] start_heart = new Vector3[3];
    int random1_heart, random2_heart;
    string[] anim = new string[3];
    //heartRiden_button
    public int check_heartriden;
    public GameObject heartline;
    Vector3 heart_presentLOC;
    int rand;
    //plusHeart_button
    public int check_plusheart;
    //

    public GameObject alice;
    public GameObject right_button, left_button;
    //
    //knight
    Animation anim_knight;
    List<string> animArray_knight;
    //spears
    Animation[] anim_spears = new Animation[2];
    List<string>[] animArray_spears = new List<string>[2];
    //penetrate
    Animation anim_penetrate;
    List<string> animArray_penetrate;
    //
    public GameObject[] items1 = new GameObject[4];
    public GameObject[] items2 = new GameObject[4];
    // switch --> 0
    public GameObject knight;
    public GameObject knife;
    public GameObject knife_angle;
    Vector3 start, end;
    // switch --> 1
    public GameObject[] spears = new GameObject[2];
    Vector3 start1, start2;
    Vector3 start_spears1, start_spears2;
    // switch -->2
    public GameObject penetrate;
    //
    Button[] item_buttons1 = new Button[4];
    Button[] item_buttons2 = new Button[4];
    //
    public int random1, random2, random;
    public int check, time;
    //stop
    public int check_stop;
    //SOUNDS
    //heartqueen
    private AudioSource[] musicPlayer_heartqueen = new AudioSource[3];
    public AudioClip music_heartqueen;
    private AudioSource[] musicPlayer_scream = new AudioSource[3];
    public AudioClip music_scream;
    //
    //heartplus
    private AudioSource musicPlayer_heartplus;
    public AudioClip music_heartplus;
    //
    //heartRiden
    private AudioSource musicPlayer_haertriden;
    public AudioClip music_heartriden;
    //
    //knight
    private AudioSource musicPlayer_knight;
    public AudioClip music_knight;
    private AudioSource musicPlayer_knife;
    public AudioClip music_knife;
    //
    //spears
    private AudioSource musicPlayer_spears_before;
    public AudioClip music_spears_before;
    private AudioSource musicPlayer_spears_after;
    public AudioClip music_spears_after;
    //

    void Start()
    {
        //Buttons
        //chatting_button
        check_chat = 0;
        present_loc = deadline.transform.localPosition;
        //heartqueen_button
        start_heart[0] = new Vector3(-1.5f, -3.8f, 0f);
        start_heart[1] = new Vector3(0, -3.8f, 0f);
        start_heart[2] = new Vector3(1.5f, -3.8f, 0f);
        anim[0] = "leftQueen_animation";
        anim[1] = "centerQueen_animation";
        anim[2] = "rightQueen_animation";
        //heartRiden_button
        check_heartriden = -1;
        //plusHeart_button
        check_plusheart = 0;
        //

        alice = GameObject.Find("Alice");
        right_button = GameObject.Find("Canvas_chat_and_button").transform.Find("Right_Button").gameObject;
        left_button = GameObject.Find("Canvas_chat_and_button").transform.Find("Left_Button").gameObject;
        //애니매이션 설정
        //knight
        anim_knight = knight.GetComponent<Animation>();
        animArray_knight = new List<string>();
        AnimationArray(animArray_knight, anim_knight);
        //spears
        for (int i = 0; i < 2; i++)
        {
            anim_spears[i] = spears[i].GetComponent<Animation>();
            animArray_spears[i] = new List<string>();
            AnimationArray(animArray_spears[i], anim_spears[i]);
        }
        //penetrate
        anim_penetrate = penetrate.GetComponent<Animation>();
        animArray_penetrate = new List<string>();
        AnimationArray(animArray_penetrate, anim_penetrate);
        //
        for (int i = 0; i < 4; i++)
        {
            item_buttons1[i] = items1[i].GetComponent<Button>();
            items1[i].SetActive(false);
        }
        for (int i = 0; i < 4; i++)
        {
            item_buttons2[i] = items2[i].GetComponent<Button>();
            items2[i].SetActive(false);
        }
        check = -1;   // 버튼 눌렀는지 안눌렀는지 판단
        //밑으로 두줄 --> 기사에서 스타트랑 엔드
        start = knight.transform.localPosition;
        end = new Vector3(start.x - 3.3f, start.y, start.z);
        //밑으로 네줄 --> 창에서 스타트
        start1 = spears[0].transform.localPosition;
        start2 = spears[1].transform.localPosition;
        start_spears1 = spears[0].transform.localPosition;
        start_spears2 = spears[1].transform.localPosition;
        time = 0;
        //밑으로 --> 관통에서 스타트위치
        //stop
        check_stop = 1;
        StartCoroutine(choose_now());
        //SOUNDS
        //heartqueen
        musicPlayer_heartqueen[0] = heartqueen[0].transform.Find("warning1").GetComponent<AudioSource>();
        musicPlayer_heartqueen[1] = heartqueen[1].transform.Find("warning2").GetComponent<AudioSource>();
        musicPlayer_heartqueen[2] = heartqueen[2].transform.Find("warning3").GetComponent<AudioSource>();
        musicPlayer_scream[0] = heartqueen[0].transform.Find("attack1").GetComponent<AudioSource>();
        musicPlayer_scream[1] = heartqueen[1].transform.Find("attack2").GetComponent<AudioSource>();
        musicPlayer_scream[2] = heartqueen[2].transform.Find("attack3").GetComponent<AudioSource>();
        //
        //heartpluse
        musicPlayer_heartplus = GameObject.Find("hearts").GetComponent<AudioSource>();
        //
        //heartriden
        musicPlayer_haertriden = GameObject.Find("heart").GetComponent<AudioSource>();
        //
        //knight
        musicPlayer_knight = GameObject.Find("knight").GetComponent<AudioSource>();
        musicPlayer_knife = GameObject.Find("angle").GetComponent<AudioSource>();
        //
        //spears
        musicPlayer_spears_before = GameObject.Find("spears").GetComponent<AudioSource>();
        musicPlayer_spears_after = GameObject.Find("spear2").GetComponent<AudioSource>();
    }
    void Update()
    {

    }
    void AnimationArray(List<string> animArray, Animation anim)
    {
        foreach(AnimationState state in anim)
        {
            animArray.Add(state.name);
        }
    }
    IEnumerator chatting_button()
    {
        yield return new WaitForSeconds(0.5f);
        check_chat = 1;
        chat.GetComponent<chats>().time /= 3;
        deadline.transform.localPosition = loc;
        yield return new WaitForSeconds(6f);
        deadline.transform.localPosition = present_loc;
        chat.GetComponent<chats>().time *= 3;
        check_chat = 0;
    }
    public static void playSound(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.clip = clip;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }
    public static void stopSound(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.clip = clip;
        audioPlayer.time = 0;
        audioPlayer.Stop();
    }
    IEnumerator heartqueen_button()
    {
        for (int i = 0; i < 2; i++)
        {
            random1_heart = Random.Range(0, 3);
            random2_heart = Random.Range(0, 3);
            if (random1_heart == random2_heart)
            {
                heartqueen[random1_heart].GetComponent<Animation>().Play(anim[random1_heart]);
                warn[random1_heart].GetComponent<SpriteRenderer>().enabled = true;
                warn[random1_heart].GetComponent<AudioSource>().enabled = true;
                playSound(music_heartqueen, musicPlayer_heartqueen[random1_heart]);
                yield return new WaitForSeconds(0.65f);
                stopSound(music_heartqueen, musicPlayer_heartqueen[random1_heart]);
                yield return new WaitForSeconds(0.35f);
                warn[random1_heart].GetComponent<SpriteRenderer>().enabled = false;
                warn[random1_heart].GetComponent<AudioSource>().enabled = false;
                yield return new WaitForSeconds(1f);
                heartqueen[random1_heart].GetComponent<SpriteRenderer>().sprite = heartqueen_sprites1;
                attack[random1_heart].GetComponent<SpriteRenderer>().enabled = true;
                attack[random1_heart].GetComponent<PolygonCollider2D>().enabled = true;
                playSound(music_scream, musicPlayer_scream[random1_heart]);
                yield return new WaitForSeconds(1f);
                heartqueen[random1_heart].GetComponent<SpriteRenderer>().sprite = heartqueen_sprites2;
                attack[random1_heart].GetComponent<SpriteRenderer>().enabled = false;
                attack[random1_heart].GetComponent<PolygonCollider2D>().enabled = false;
            }
            else
            {
                heartqueen[random1_heart].GetComponent<Animation>().Play(anim[random1_heart]);
                heartqueen[random2_heart].GetComponent<Animation>().Play(anim[random2_heart]);
                warn[random1_heart].GetComponent<SpriteRenderer>().enabled = true;
                warn[random2_heart].GetComponent<SpriteRenderer>().enabled = true;
                warn[random1_heart].GetComponent<AudioSource>().enabled = true;
                warn[random2_heart].GetComponent<AudioSource>().enabled = true;
                playSound(music_heartqueen, musicPlayer_heartqueen[random1_heart]);
                yield return new WaitForSeconds(0.65f);
                stopSound(music_heartqueen, musicPlayer_heartqueen[random1_heart]);
                yield return new WaitForSeconds(0.35f);
                warn[random1_heart].GetComponent<SpriteRenderer>().enabled = false;
                warn[random2_heart].GetComponent<SpriteRenderer>().enabled = false;
                warn[random1_heart].GetComponent<AudioSource>().enabled = false;
                warn[random2_heart].GetComponent<AudioSource>().enabled = false;
                yield return new WaitForSeconds(1f);
                heartqueen[random1_heart].GetComponent<SpriteRenderer>().sprite = heartqueen_sprites1;
                heartqueen[random2_heart].GetComponent<SpriteRenderer>().sprite = heartqueen_sprites1;
                attack[random1_heart].GetComponent<SpriteRenderer>().enabled = true;
                attack[random1_heart].GetComponent<PolygonCollider2D>().enabled = true;
                attack[random2_heart].GetComponent<SpriteRenderer>().enabled = true;
                attack[random2_heart].GetComponent<PolygonCollider2D>().enabled = true;
                playSound(music_scream, musicPlayer_scream[random1_heart]);
                yield return new WaitForSeconds(1f);
                heartqueen[random1_heart].GetComponent<SpriteRenderer>().sprite = heartqueen_sprites2;
                heartqueen[random2_heart].GetComponent<SpriteRenderer>().sprite = heartqueen_sprites2;
                attack[random1_heart].GetComponent<SpriteRenderer>().enabled = false;
                attack[random1_heart].GetComponent<PolygonCollider2D>().enabled = false;
                attack[random2_heart].GetComponent<SpriteRenderer>().enabled = false;
                attack[random2_heart].GetComponent<PolygonCollider2D>().enabled = false;
                //heartqueen[random1_heart].transform.localPosition = start_heart[random1_heart];
                //heartqueen[random2_heart].transform.localPosition = start_heart[random2_heart];
            }
            yield return new WaitForSeconds(2.1f);
        }
    }
    IEnumerator heartRiden_button()
    {
        yield return new WaitForSeconds(0.5f);
        check_heartriden = Random.Range(0, 2);
        playSound(music_heartriden, musicPlayer_haertriden);
        yield return new WaitForSeconds(10f);
        check_heartriden = -1;
    }
    IEnumerator plusHeart_button()
    {
        yield return new WaitForSeconds(0.5f);
        playSound(music_heartplus, musicPlayer_heartplus);
        check_plusheart = 1;
    }
    public void heartqueen_button_press()
    {
        check = 0;
    }
    public void chatting_button_press()
    {
        check = 1;
    }
    public void heartRiden_button_press()
    {
        check = 2;
    }
    public void plusHeart_button_press()
    {
        check = 3;
    }
    public IEnumerator choose_now()
    {
        for (int i = 0; i < 12; i++)
        {
            random1 = Random.Range(0, 4);
            random2 = Random.Range(0, 4);
            random = Random.Range(0, 3);
            //case 0은 기사!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (random == 0)
            {
                yield return new WaitForSeconds(3f);
                knife.GetComponent<PolygonCollider2D>().enabled = false;
                check_stop = 0;
                playSound(music_knight, musicPlayer_knight);
                knight.GetComponent<Animation>().Play(animArray_knight[0]);
                yield return new WaitForSeconds(2f);
                items1[random1].SetActive(true);
                items2[random2].SetActive(true);
                for (int t = 0; t < 30; t++)
                {
                    yield return new WaitForSeconds(0.1f);
                    if (check != -1) break;
                }
                items1[random1].SetActive(false);
                items2[random2].SetActive(false);
                if (check == -1)
                {
                    knife.GetComponent<PolygonCollider2D>().enabled = true;
                    playSound(music_knife, musicPlayer_knife);
                    knife_angle.GetComponent<Animation>().Play("angle_animation");
                    yield return new WaitForSeconds(2f);
                    knight.GetComponent<Animation>().Play(animArray_knight[1]);
                    check_stop = 1;
                }
                else
                {
                    check_stop = 1;
                    knight.GetComponent<Animation>().Play(animArray_knight[1]);
                    if (check == 0)
                    {
                        yield return StartCoroutine(heartqueen_button());
                    }
                    else if (check == 1)
                    {
                        yield return StartCoroutine(chatting_button());
                    }
                    else if (check == 2)
                    {
                        yield return StartCoroutine(heartRiden_button());
                    }
                    else if (check == 3)
                    {
                        yield return StartCoroutine(plusHeart_button());
                    }
                }
                yield return new WaitForSeconds(3f);
                check = -1;
            }
            //case 1은 양 옆 창!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            else if (random == 1) 
            {
                yield return new WaitForSeconds(3f);
                spears[0].GetComponent<PolygonCollider2D>().enabled = false;
                spears[1].GetComponent<PolygonCollider2D>().enabled = false;
                check_stop = 0;
                playSound(music_spears_before, musicPlayer_spears_before);
                spears[0].GetComponent<Animation>().Play(animArray_spears[0][0]);
                spears[1].GetComponent<Animation>().Play(animArray_spears[1][0]);
                yield return new WaitForSeconds(2f);
                items1[random1].SetActive(true);
                items2[random2].SetActive(true);
                for (int t = 0; t < 30; t++)
                {
                    yield return new WaitForSeconds(0.1f);
                    if (check != -1) break;
                }
                items1[random1].SetActive(false);
                items2[random2].SetActive(false);
                if (check == -1)
                {
                    spears[0].GetComponent<PolygonCollider2D>().enabled = true;
                    spears[1].GetComponent<PolygonCollider2D>().enabled = true;
                    playSound(music_spears_after, musicPlayer_spears_after);
                    spears[0].GetComponent<Animation>().Play(animArray_spears[0][1]);
                    spears[1].GetComponent<Animation>().Play(animArray_spears[1][1]);
                    yield return new WaitForSeconds(2f);
                    check_stop = 1;
                }
                else
                {
                    check_stop = 1;
                    if (check == 0)
                    {
                        yield return StartCoroutine(heartqueen_button());
                    }
                    else if (check == 1)
                    {
                        yield return StartCoroutine(chatting_button());
                    }
                    else if (check == 2)
                    {
                        yield return StartCoroutine(heartRiden_button());
                    }
                    else if (check == 3)
                    {
                        yield return StartCoroutine(plusHeart_button());
                    }
                }
                yield return new WaitForSeconds(3f);
                check = -1;
            }
            //case 2은 관통 창!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            else if (random == 2)
            {
                yield return new WaitForSeconds(3f);
                penetrate.GetComponent<PolygonCollider2D>().enabled = false;
                check_stop = 0;
                playSound(music_spears_before, musicPlayer_spears_before);
                penetrate.GetComponent<Animation>().Play(animArray_penetrate[1]);
                yield return new WaitForSeconds(2f);
                items1[random1].SetActive(true);
                items2[random2].SetActive(true);
                for(int t = 0; t < 30; t++)
                {
                    yield return new WaitForSeconds(0.1f);
                    if (check != -1) break;
                }
                items1[random1].SetActive(false);
                items2[random2].SetActive(false);
                if (check == -1)
                {
                    penetrate.GetComponent<PolygonCollider2D>().enabled = true;
                    playSound(music_spears_after, musicPlayer_spears_after);
                    penetrate.GetComponent<Animation>().Play(animArray_penetrate[0]);
                    yield return new WaitForSeconds(2f);
                    check_stop = 1;
                }
                else
                {
                    check_stop = 1;
                    if (check == 0)
                    {
                        yield return StartCoroutine(heartqueen_button());
                    }
                    else if (check == 1)
                    {
                        yield return StartCoroutine(chatting_button());
                    }
                    else if (check == 2)
                    {
                        yield return StartCoroutine(heartRiden_button());
                    }
                    else if (check == 3)
                    {
                        yield return StartCoroutine(plusHeart_button());
                    }
                }
                yield return new WaitForSeconds(3f);
                check = -1;
            }
        }
        Debug.Log("끝났다");
    }
}


