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
        talkData.Add(1000, new string[] { "안녕?:1", "이곳에 처음 왔구나?:2" });
        talkData.Add(2000, new string[] { "좋은아침?:4", "밥은 먹었니?:6" });

        talkData.Add(100, new string[] { "평범한 집이다. 누가 살고있을까?" });
        talkData.Add(200, new string[] { "평범한 나무다." });
        talkData.Add(300, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(400, new string[] { "평범한 나무상자다." });
        talkData.Add(500, new string[] { "속이 비어있는 것 같은 박스다." });

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
