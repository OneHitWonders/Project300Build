using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestUIManager : MonoBehaviour {


    public static QuestUIManager uiManager;


    //bools to check if quests are avaliable/running/active
    public bool questAvaliable = false;
    public bool questRunning = false;
    private bool questPanelActive = false;
    private bool questLogPanelActive = false;

    //Panels
    public GameObject questPanel;
    public GameObject questLogPanel;

    //Quest object
    private QuestObject currentQuestObject;


    //Quest Lists
    public List<Quest> avaliableQuests = new List<Quest>();
    public List<Quest> activeQuests = new List<Quest>();

    //Buttons
    public GameObject qButton;
    public GameObject qLogButton;
    private List<GameObject> qButtons = new List<GameObject>();

    private GameObject acceptButton;
    private GameObject giveUpButton;
    private GameObject completeButton;

    //Spacer
    public Transform qButtonSpacer1; //spacer for qButton
    public Transform qButtonSpacer2; // spacer for running qButton;
    public Transform qLogButtonSpacer; // spacer for running qLog;

    //QUEST INFOS
    public Text questTitle;
    public Text questDesctription;
    public Text questSummary;

    //QUEST LOG INFOS
    public Text questLogTitle;
    public Text questLogDesctription;
    public Text questLogSummary;

    void Awake()
    {
        if (uiManager == null)
        {
            uiManager = this;

        }
        else if (uiManager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        HideQuestPanel();
    }



    // Update is called once per frame //PRESS Q TO SHOW QUESTS
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            questLogPanelActive = !questLogPanelActive;
            //ShowQuestLogPanel();
            //show questlog panel
        }
    }

    //CALLED FROM QUEST OBJECT (npc character/radio tower)
    public void CheckQuests(QuestObject questObject)
    {
        currentQuestObject = questObject;
        QuestManager.questManager.QuestRequest(questObject);
        if ((questRunning || questAvaliable) && !questPanelActive)
        {
            //Show the quest panel
            ShowQuestPanel();

        }
        else
        {
            Debug.Log("No Quests Avaliable");
        }
    }

    //show panel
    public void ShowQuestPanel()
    {
        questPanelActive = true;
        questPanel.SetActive(questPanelActive);
        //FILL IN DATA
        fillQuestButtons();
    }

    //Show quest log
    public void ShowQuestLog(Quest activeQuest)
    {
        questLogTitle.text = activeQuest.title;
        if (activeQuest.progress == Quest.QuestProgress.ACCEPTED)
        {
            questLogDesctription.text = activeQuest.hint;
            questLogSummary.text = activeQuest.questObjective + " : " + activeQuest.questObjectiveCount + " / " + activeQuest.questObjectiveRequired;

        }
        else if (activeQuest.progress == Quest.QuestProgress.COMPLETED)
        {
            questLogDesctription.text = activeQuest.congratulation;
            questLogSummary.text = activeQuest.questObjective + " : " + activeQuest.questObjectiveCount + " / " + activeQuest.questObjectiveRequired;

        }

    }


    public void HideQuestLogPanel()
    {
        questLogPanelActive = false;

        questLogTitle.text = "";
        questLogDesctription.text = "";
        questLogSummary.text = "";

        //CLEAR BUTTONS
        for (int i = 0; i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);
        }

        qButtons.Clear();
        questLogPanel.SetActive(questLogPanelActive);

    }


    public void ShowQuestLogPanel()
    {
        questLogPanel.SetActive(true);
        if (questLogPanelActive && !questPanelActive)
        {
            foreach (Quest curQuest in QuestManager.questManager.currentQuestList)
            {
                GameObject questButton = Instantiate(qLogButton);
                QLogButtonScript qButton = questButton.GetComponent<QLogButtonScript>();

                qButton.questID = curQuest.id;
                qButton.questTitle.text = curQuest.title;

                questButton.transform.SetParent(qLogButtonSpacer, false);
                qButtons.Add(questButton);
            }
        }

        else if (!questLogPanelActive && questPanelActive)
        {
            HideQuestLogPanel();
        }
            
    }

    //quest log


   //HIDE QUEST PANEL
   public void HideQuestPanel()
    {
        questPanelActive = false;
        questAvaliable = false;
        questRunning = false;

        //CLEAR TEXT
        questTitle.text = "";
        questDesctription.text = "";
        questSummary.text = "";

        //CLEAR LISTS
        avaliableQuests.Clear();
        activeQuests.Clear();

        //CLEAR BUTTON LIST
        for (int i = 0; i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);
        }
        qButtons.Clear();
        //HIDE PANEL
        questPanel.SetActive(questPanelActive);
    }


    //FILL BUTTONS FOR QUEST PANEL
    void fillQuestButtons()
    {
        foreach (Quest availableQuest in avaliableQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qBScript = questButton.GetComponent<QButtonScript>();

            qBScript.questID = availableQuest.id;
            qBScript.questTitle.text = availableQuest.title;

            questButton.transform.SetParent(qButtonSpacer1, false);
            qButtons.Add(questButton);
        }

        foreach (Quest activeQuest in activeQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qBScript = questButton.GetComponent<QButtonScript>();

            qBScript.questID = activeQuest.id;
            qBScript.questTitle.text = activeQuest.title;

            questButton.transform.SetParent(qButtonSpacer2, false);
            qButtons.Add(questButton);
        }
    }

    //SHOW QUEST ON BUTTON PRESS
    public void ShowSelectedQuest(int questID)
    {

        for (int i = 0; i < avaliableQuests.Count; i++)
        {
            if (avaliableQuests[i].id == questID)
            {
                questTitle.text = avaliableQuests[i].title;
                if (avaliableQuests[i].progress == Quest.QuestProgress.AVALIABLE)
                {
                    questDesctription.text = avaliableQuests[i].description;
                    questSummary.text = avaliableQuests[i].questObjective + " : " + avaliableQuests[i].questObjectiveCount + " / " + avaliableQuests[i].questObjectiveRequired;
                }
            }
        }

        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].id == questID)
            {
                questTitle.text = activeQuests[i].title;
                if (activeQuests[i].progress == Quest.QuestProgress.ACCEPTED)
                {
                    questDesctription.text = activeQuests[i].hint;
                    questSummary.text = activeQuests[i].questObjective + " : " + activeQuests[i].questObjectiveCount + " / " + activeQuests[i].questObjectiveRequired;
                }
                else if (activeQuests[i].progress == Quest.QuestProgress.COMPLETED)
                {
                    questDesctription.text = activeQuests[i].congratulation;
                }

            }
        }

    }
}
