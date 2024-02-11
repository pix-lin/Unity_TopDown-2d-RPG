using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public Animator talkSpace_Npc;
    public Animator talkSpace_Object;
    public Animator portraitAnime;
    public Sprite prePortrait;
    public TypeEffect talk_NPC;
    public TypeEffect talk_Object;
    public Image portraitImg;
    public GameObject scanObject;
    public GameObject menuSet;
    public GameObject player;
    public TextMeshProUGUI questText;
    public bool isSubMenu;
    public bool isAction;
    public int talkIndex;


    private void Awake()
    {
        talkSpace_Npc.SetBool("IsShow", false);
        talkSpace_Object.SetBool("IsShow", false);
    }

    private void Start()
    {
        GameLoad();
        questText.text = questManager.CheckQuest();
    }

    private void Update()
    {
        //Sub Menu
        if (Input.GetButtonDown("Cancel"))
        {
            SubMenuActive(); 
        }   
    }

    public void SubMenuActive()
    {
        if (menuSet.activeSelf) //서브메뉴 닫기
        {
            Time.timeScale = 1;
            menuSet.SetActive(false);
            isSubMenu = false;
        }
        else //서브메뉴 열기
        {
            menuSet.SetActive(true);
            Time.timeScale = 0;
            isSubMenu = true;
        }
    }

    public void Action(GameObject scanObj)
    {
        //Get Current Object
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNPC);

        //Visible Talk for Action
        if (objData.isNPC)
            talkSpace_Npc.SetBool("IsShow", isAction);
        else
            talkSpace_Object.SetBool("IsShow", isAction);

    }

    void Talk(int id, bool isNPC)
    {

        int questTalkIndex = 0;
        string talkData = "";

        //Set Talk Data
        //Skip
        if (talk_NPC.isAnime)
        {
            talk_NPC.SetMsg("");
            return;
        }

        else if (talk_Object.isAnime)
        {
            talk_Object.SetMsg("");
            return;
        }

        //Non-Skip
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

        //End Talk
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questManager.CheckQuest(id);
            questText.text = questManager.CheckQuest();
            return;
        }

        //Continue Talk
        if (isNPC)
        {
            talk_NPC.SetMsg(talkData.Split(':')[0]);

            //Show Portrait
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);

            if(prePortrait != portraitImg.sprite)
            {
                portraitAnime.SetTrigger("DoEffect");
                prePortrait = portraitImg.sprite;
            }
            
        }
        else
        {
            talk_Object.SetMsg(talkData);
            //portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();

        menuSet.SetActive(false);
        //player.x, player.y
        //Quest Id
        //Qurest Action Index
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");


        player.transform.position = new Vector3(x, y, 0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        questManager.ControlObject();
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
