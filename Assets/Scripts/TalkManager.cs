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

        talkData.Add(100, new string[] { "평범한 집이다. 누가 살고있을까?"});
        talkData.Add(200, new string[] { "평범한 나무다." });
        talkData.Add(300, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(400, new string[] { "평범한 나무상자다." });
        talkData.Add(500, new string[] { "속이 비어있는 것 같은 박스다." });

        //talkData.Add(5000, new string[] { "동전을 발견했다." });

        //Quest Talk
        talkData.Add(1000 + 10, new string[] { "어서 와:0", "이 마을에는 놀라운 전설이 있다는데:1", "오른쪽 호수 쪽에 루도가 알려줄꺼야.:0" });
        talkData.Add(1000 + 11, new string[] { "아직 못만났어?:0", "루도는 오른쪽 호수 쪽에 있어.:1"});
        talkData.Add(2000 + 11, new string[] { "반가워.:5", "이 호수의 전설을 들으러 온거야?:6", "그럼 일 좀 하나 해주면 좋을텐데..:5", "내 집 근처에 떨어진 동전 좀 주워줬으면 해. 10개만 주워다주면 고맙겠어.:4"});

        talkData.Add(1000 + 20, new string[] { "루도의 동전?:0", "돈을 흘리고 다니면 못쓰지!:2", "나중에 루도에게 한마디 해야겠어.:3"});
        talkData.Add(2000 + 21, new string[] { "찾으면 꼭 좀 가져다줘:4" });
        talkData.Add(2000 + 22, new string[] { "아마 동전은 집 근처에 있을거야.:4" });
        talkData.Add(5000 + 22, new string[] { "근처에서 동전을 찾았다." });
        talkData.Add(2000 + 23, new string[] { "엇 찾아줘서 고마워:6"});

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
        if (!talkData.ContainsKey(id)) //현재 퀘스트 대사가 없다면
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                //퀘스트 맨 처음 대사마저 없을 때
                //기본 대사를 가지고 온다.
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                //해당 퀘스트 진행 중 현재 대사가 없을 때
                //이전 퀘스트 대사를 가지고 온다.
                return GetTalk(id - id % 10, talkIndex);
            }   
        }

        //현재 퀘스트 대사 반환
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
