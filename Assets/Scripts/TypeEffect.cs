using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds;
    string targetMsg;
    TextMeshProUGUI msgText;
    int index;

    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
    }

    void Effecting()
    {
        index++;
    }

    void EffectEnd()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
