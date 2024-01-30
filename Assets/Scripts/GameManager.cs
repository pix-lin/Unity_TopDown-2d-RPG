using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject talkSpace;
    public TextMeshProUGUI talkText;
    public GameObject scanObject;
    public bool isAction;

    private void Awake()
    {
        talkSpace.SetActive(false);
    }

    public void Action(GameObject scanObj)
    {
        if (isAction) //Exit Action
        {
            isAction = false;
        }
        else //Enter Action
        {
            isAction = true;
            scanObject = scanObj;
            talkText.text = "�̰��� �̸��� " + scanObj.name + "�̶�� �Ѵ�.";
        }
        talkSpace.SetActive(isAction);
    }

}
