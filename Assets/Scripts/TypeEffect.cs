using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds;
    public GameObject EndCursor;
    public bool isAnime;

    string targetMsg;
    TextMeshProUGUI msgText;
    AudioSource audioSource;
    
    int index;
    float interval;

    private void Awake()
    {
        msgText = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }
    public void SetMsg(string msg)
    {
        if (isAnime)
        {
            CancelInvoke();
            msgText.text = targetMsg;
            EffectEnd();
        }

        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        //Start Animation
        interval = 1.0f / CharPerSeconds;
        Debug.Log(interval);

        isAnime = true;
        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        if(msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];

        //Sounding
        if (targetMsg[index] != ' ' || targetMsg[index] != '.')
            audioSource.Play();

        index++;

        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isAnime = false;
        EndCursor.SetActive(true);
    }
}
