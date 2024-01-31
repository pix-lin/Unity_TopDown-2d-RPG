using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?", "�̰��� ó�� �Ա���?" });
        talkData.Add(2000, new string[] { "������ħ?", "���� �Ծ���?" });

        talkData.Add(100, new string[] { "����� ���̴�. ���� ���������?" });
        talkData.Add(200, new string[] { "����� ������." });
        talkData.Add(300, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });
        talkData.Add(400, new string[] { "����� �������ڴ�." });
        talkData.Add(500, new string[] { "���� ����ִ� �� ���� �ڽ���." });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
       else 
            return talkData[id][talkIndex];
    }
}
