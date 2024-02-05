using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList; 

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("���� ������ ��ȭ�ϱ�", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("�絵�� ���� ã���ֱ�", new int[] { 1000, 2000, 5000, 2000}));
        questList.Add(30, new QuestData("����Ʈ�� Ŭ�����Ͽ����ϴ�.", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public void CheckQuest(int id)
    {
        //Next Talk NPC
        if(id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        //Control Quest Object
        ControlObject();

        //Talk Complete & Next Quest 
        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return;
    }

    public string CheckQuest()
    {
        //Quest Name
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2) //����Ʈ1������ ��ȭ�� ��� ������ ��
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex <= 2)
                    questObject[0].SetActive(true);
                else if (questActionIndex == 3) //���� �԰� �� ù NPC
                    questObject[0].SetActive(false);
                break;
        }
    }
}
