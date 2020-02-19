using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource musicPlayer;

    public string objectName;
    public GameObject controlPos;
    public Transform tempT;
    bool isPlayed = false;
    void Start()
    {
        musicPlayer = this.gameObject.GetComponent<AudioSource>();
        //musicPlayer.time = 0;
    }

    void Update()
    {
        playSound();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StartLine"))
        {
            if (objectName.Equals("Cat") || objectName.Equals("Neon"))

                isPlayed = false;
        }
    }

    void playSound()
    {
        switch (objectName)
        {
            case "Neon":
                if (gameObject.transform.position.y >= -2.0f && !musicPlayer.isPlaying && !isPlayed)
                {//장애물이 EndLine에 부딪혀서 다음 위치로 Translate 되는 순간에
                    //오디오가 틀어집니다. 근데 왜 그러는지 모르겠어!!!
                    musicPlayer.Play();
                    isPlayed = true;
                }
                break;
            case "Cat":
                if (gameObject.transform.position.y >= -2.0f && !musicPlayer.isPlaying && !isPlayed)
                {
                    musicPlayer.Play();
                    isPlayed = true;
                }
                break;
            case "Teapot":
                if (gameObject.transform.position.y >= -6.5f && !musicPlayer.isPlaying)
                {
                    musicPlayer.Play();
                    //if (!teapotItem.teaOn)
                    //{
                    //    musicPlayer.Stop();
                    //}
                    if (gameObject.transform.position.y >= 1f && musicPlayer.isPlaying)
                    {
                        musicPlayer.Stop();
                    }
                }
                break;
            case "Flash":
                if (gameObject.transform.position.y >= -6.5f && !musicPlayer.isPlaying)
                {
                    musicPlayer.Play();
                    //if (!flashItem1.flashOn)
                    //{
                    //    musicPlayer.Stop();
                    //}
                    if (gameObject.transform.position.y >= 0.5f && musicPlayer.isPlaying)
                    {
                        musicPlayer.Stop();
                    }
                }
                break;
            case "Clock":
                if (gameObject.transform.position.y >= -5f && !musicPlayer.isPlaying)
                {
                    musicPlayer.Play();
                    if (gameObject.transform.position.y >= 5f && musicPlayer.isPlaying)
                    {
                        musicPlayer.Stop();
                    }
                }
                break;
        }



    }

}