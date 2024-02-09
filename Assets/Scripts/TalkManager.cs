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

        talkData.Add(100, new string[] { "����� ���̴�. ���� ���������?"});
        talkData.Add(200, new string[] { "����� ������." });
        talkData.Add(300, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });
        talkData.Add(400, new string[] { "����� �������ڴ�." });
        talkData.Add(500, new string[] { "���� ����ִ� �� ���� �ڽ���." });

        //talkData.Add(5000, new string[] { "������ �߰��ߴ�." });

        //Quest Talk
        talkData.Add(1000 + 10, new string[] { "� ��:0", "�� �������� ���� ������ �ִٴµ�:1", "������ ȣ�� �ʿ� �絵�� �˷��ٲ���.:0" });
        talkData.Add(1000 + 11, new string[] { "���� ��������?:0", "�絵�� ������ ȣ�� �ʿ� �־�.:1"});
        talkData.Add(2000 + 11, new string[] { "�ݰ���.:5", "�� ȣ���� ������ ������ �°ž�?:6", "�׷� �� �� �ϳ� ���ָ� �����ٵ�..:5", "�� �� ��ó�� ������ ���� �� �ֿ������� ��. 10���� �ֿ����ָ� ���ھ�.:4"});

        talkData.Add(1000 + 20, new string[] { "�絵�� ����?:0", "���� �긮�� �ٴϸ� ������!:2", "���߿� �絵���� �Ѹ��� �ؾ߰ھ�.:3"});
        talkData.Add(2000 + 21, new string[] { "ã���� �� �� ��������:4" });
        talkData.Add(2000 + 22, new string[] { "�Ƹ� ������ �� ��ó�� �����ž�.:4" });
        talkData.Add(5000 + 22, new string[] { "��ó���� ������ ã�Ҵ�." });
        talkData.Add(2000 + 23, new string[] { "�� ã���༭ ����:6"});

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
        if (!talkData.ContainsKey(id)) //���� ����Ʈ ��簡 ���ٸ�
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                //����Ʈ �� ó�� ��縶�� ���� ��
                //�⺻ ��縦 ������ �´�.
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                //�ش� ����Ʈ ���� �� ���� ��簡 ���� ��
                //���� ����Ʈ ��縦 ������ �´�.
                return GetTalk(id - id % 10, talkIndex);
            }   
        }

        //���� ����Ʈ ��� ��ȯ
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
