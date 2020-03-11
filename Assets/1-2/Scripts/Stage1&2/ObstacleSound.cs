using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSound : MonoBehaviour
{
    private AudioSource musicPlayer;
    public AudioClip sound;

    public int start;
    public int end;

    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Time.timeScale == 0)
        {
            musicPlayer.Stop();
        }

        if(transform.position.y > start && !musicPlayer.isPlaying)
        {
            musicPlayer.Play();
        }

        if(transform.position.y == end && musicPlayer.isPlaying)
        {
            musicPlayer.Stop();
        }
    }
}
