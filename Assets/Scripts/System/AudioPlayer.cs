using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource musicPlayer;

    public string objectName;
    public GameObject controlPos;
    public Transform tempT;

    void Start()
    {
        
        controlPos = GameObject.Find("MusicControlPos");
        tempT = controlPos.transform;
    }
    
    void Update()
    {
        playSound();
    }

    
    void playSound()
    {
        switch (objectName)
        {
            case "Neon":
                if (gameObject.transform.position.y >= -2.0f)
                {//장애물이 EndLine에 부딪혀서 다음 위치로 Translate 되는 순간에
                    //오디오가 틀어집니다. 근데 왜 그러는지 모르겠어!!!
                    musicPlayer = this.gameObject.GetComponent<AudioSource>();
                    musicPlayer.time = 0;
                    musicPlayer.Play();
                }
                break;
            case "Cat":
                if (gameObject.transform.position.y >= -2.0f)
                {
                    musicPlayer = this.gameObject.GetComponent<AudioSource>();
                    musicPlayer.time = 0;
                    musicPlayer.Play();
                }
                break;
            case "Teapot":
                if (gameObject.transform.position.y >= -6.5f)
                {
                    musicPlayer = this.gameObject.GetComponent<AudioSource>();
                    musicPlayer.time = 0;
                    musicPlayer.Play();
                    //if (!teapotItem.teaOn)
                    //{
                    //    musicPlayer.Stop();
                    //}
                }
                break;
            case "Flash":
                if (gameObject.transform.position.y >= -6.5f)
                {
                    musicPlayer = this.gameObject.GetComponent<AudioSource>();
                    musicPlayer.time = 0;
                    musicPlayer.Play();
                    //if (!flashItem1.flashOn)
                    //{
                    //    musicPlayer.Stop();
                    //}
                }
                break;
            case "Clock":
                if (gameObject.transform.position.y >= -6.5f)
                {
                    musicPlayer = this.gameObject.GetComponent<AudioSource>();
                    musicPlayer.time = 0;
                    musicPlayer.Play();
                    if (gameObject.transform.position.y >= -6.5f)
                    {
                        musicPlayer.Stop();
                    }
                }
                break;
        }



    }

}

