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
        talkData.Add(1000, new string[] { "안녕?", "이곳에 처음 왔구나?" });
        talkData.Add(2000, new string[] { "좋은아침?", "밥은 먹었니?" });

        talkData.Add(100, new string[] { "평범한 집이다. 누가 살고있을까?" });
        talkData.Add(200, new string[] { "평범한 나무다." });
        talkData.Add(300, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(400, new string[] { "평범한 나무상자다." });
        talkData.Add(500, new string[] { "속이 비어있는 것 같은 박스다." });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
       else 
            return talkData[id][talkIndex];
    }
}
