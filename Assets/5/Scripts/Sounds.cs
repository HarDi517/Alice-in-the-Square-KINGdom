using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource musicPlayer;
    public AudioClip music;
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        playSound(music, musicPlayer);
    }

    public static void playSound(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }
}
