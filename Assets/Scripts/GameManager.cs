using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public Animator talkSpace;
    public Animator portraitAnime;
    public Sprite prePortrait;
    public TypeEffect talk;
    public Image portraitImg;
    public GameObject scanObject;
    public GameObject menuSet;
    public GameObject player;
    public TextMeshProUGUI questText;
    public bool isAction;
    public int talkIndex;


    private void Awake()
    {
        talkSpace.SetBool("IsShow", false);
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
            if (menuSet.activeSelf)
            {
                //Time.timeScale = 1;
                menuSet.SetActive(false);
            }  
            else
            {
                menuSet.SetActive(true);
                //Time.timeScale = 0;
            } 
        }
           
    }
    public void Action(GameObject scanObj)
    {
        //Get Current Object
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNPC);

        //Visible Talk for Action
        talkSpace.SetBool("IsShow", isAction);
    }

    void Talk(int id, bool isNPC)
    {

        int questTalkIndex = 0;
        string talkData = "";

        //Set Talk Data
        if (talk.isAnime)
        {
            talk.SetMsg("");
            return;
        }
   
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
            talk.SetMsg(talkData.Split(':')[0]);

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
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1, 1, 1, 0);
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
