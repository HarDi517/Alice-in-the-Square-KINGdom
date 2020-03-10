using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeEffect : MonoBehaviour
{
    public Text TitleText;
    string originText;
    string subText;
    public AudioSource typingSound;

    void Start()
    {
        typingSound = GetComponent<AudioSource>();
        StartCoroutine(Wait());
        originText = "앨리스,\n\n추락해도 괜찮아 ";
    }

    IEnumerator Typing()
    {
        typingSound.Play();
        for(int i = 0; i < originText.Length; i++)
        {
            yield return new WaitForSeconds(0.1f);
            subText += originText.Substring(0, i);
            TitleText.text = subText;
            subText = "";
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MasterScene");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.3f);
        StartCoroutine(Typing());
    }
}
