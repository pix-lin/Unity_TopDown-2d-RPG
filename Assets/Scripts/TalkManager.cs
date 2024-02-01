using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public Sprite[] portraitArray;
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //Talk Data
        talkData.Add(1000, new string[] { "�ȳ�?:1", "�̰��� ó�� �Ա���?:2" });
        talkData.Add(2000, new string[] { "������ħ?:4", "���� �Ծ���?:6" });

        talkData.Add(100, new string[] { "����� ���̴�. ���� ���������?" });
        talkData.Add(200, new string[] { "����� ������." });
        talkData.Add(300, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });
        talkData.Add(400, new string[] { "����� �������ڴ�." });
        talkData.Add(500, new string[] { "���� ����ִ� �� ���� �ڽ���." });

        //Quest Talk
        talkData.Add(1000 + 10, new string[] { "� ��:0", "�� �������� ���� ������ �ִٴµ�:1", "������ ȣ�� �ʿ� �絵�� �˷��ٲ���.:0" });
        talkData.Add(2000 + 11, new string[] { "�ݰ���.:5", "�� ȣ���� ������ ������ �°ž�?:6", "�׷� �� �� �ϳ� ���ָ� �����ٵ�..:5", "�� �� ��ó�� ������ ���� �� �ֿ������� ��. 10���� �ֿ����ָ� ���ھ�.:4"});

        talkData.Add(2000 + 20, new string[] { "����. ������ ������ ã�ƿԱ���!:4", "���� �糪���� ã�ư��� ������ ���� �̾߱⸦ �� ����.:7"});
        talkData.Add(1000 + 21, new string[] { "�絵�� ��Ź�� ����־�����.:1", "�� ȣ������ Ŀ�ٶ� ������ ����־�.:0", "�׸��� �� ������ ��õ �� ���� ���븦 �����:0", "�׷��� �ֱٺ��� ȣ������ �̻��� ������ ���δٴ� �ҹ��� �����־�!:2" });

        //Portrait Data
        portraitData.Add(1000 + 0, portraitArray[0]);
        portraitData.Add(1000 + 1, portraitArray[1]);
        portraitData.Add(1000 + 2, portraitArray[2]);
        portraitData.Add(1000 + 3, portraitArray[3]);

        portraitData.Add(2000 + 4, portraitArray[4]);
        portraitData.Add(2000 + 5, portraitArray[5]);
        portraitData.Add(2000 + 6, portraitArray[6]);
        portraitData.Add(2000 + 7, portraitArray[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
       else 
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
