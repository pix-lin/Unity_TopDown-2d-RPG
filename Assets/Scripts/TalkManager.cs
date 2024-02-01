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
        talkData.Add(1000, new string[] { "안녕?:1", "이곳에 처음 왔구나?:2" });
        talkData.Add(2000, new string[] { "좋은아침?:4", "밥은 먹었니?:6" });

        talkData.Add(100, new string[] { "평범한 집이다. 누가 살고있을까?" });
        talkData.Add(200, new string[] { "평범한 나무다." });
        talkData.Add(300, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(400, new string[] { "평범한 나무상자다." });
        talkData.Add(500, new string[] { "속이 비어있는 것 같은 박스다." });

        //Quest Talk
        talkData.Add(1000 + 10, new string[] { "어서 와:0", "이 마을에는 놀라운 전설이 있다는데:1", "오른쪽 호수 쪽에 루도가 알려줄꺼야.:0" });
        talkData.Add(2000 + 11, new string[] { "반가워.:5", "이 호수의 전설을 들으러 온거야?:6", "그럼 일 좀 하나 해주면 좋을텐데..:5", "내 집 근처에 떨어진 동전 좀 주워줬으면 해. 10개만 주워다주면 고맙겠어.:4"});

        talkData.Add(2000 + 20, new string[] { "고마워. 동전을 무사히 찾아왔구나!:4", "이제 루나에게 찾아가서 전설에 관한 이야기를 들어도 좋아.:7"});
        talkData.Add(1000 + 21, new string[] { "루도의 부탁을 들어주었구나.:1", "이 호수에는 커다란 공룡이 살고있어.:0", "그리고 그 공룡은 수천 년 전에 자취를 감췄대:0", "그런데 최근부터 호숫가에 이상한 형상이 보인다는 소문이 돌고있어!:2" });

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
