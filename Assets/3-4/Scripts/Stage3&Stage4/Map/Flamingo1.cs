using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamingo1 : MonoBehaviour
{
    public float flamingoTurnSpeed = 10f;
    public AudioSource audioSource;
    public AudioSource flamingoFast;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        gameObject.transform.Rotate(0, 0, flamingoTurnSpeed * Time.deltaTime);

        if (gameObject.transform.position.y > -8f && !audioSource.isPlaying)
            audioSource.Play();
        if (gameObject.transform.position.y > 2f)
        {
            audioSource.Stop();
            flamingoFast.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndLine"))
            flamingoTurnSpeed = 10f;
    }

}
