using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QButtonScript : MonoBehaviour {

    public int questID;
    public Text questTitle;

    private GameObject acceptButton;
    private GameObject giveUpButton;
    private GameObject completeButton;

    private QButtonScript acceptButtonScript;
    private QButtonScript giveUpButtonScript;
    private QButtonScript CompleteButtonScript;


  void  Start()
    {
        acceptButton = GameObject.Find("QuestCanvas/QuestPanel/QuestDescription/GameObject/Accept").gameObject;
        acceptButtonScript = acceptButton.GetComponent<QButtonScript>();

        giveUpButton = GameObject.Find("GiveUp").gameObject;
        giveUpButtonScript = giveUpButton.GetComponent<QButtonScript>();

        completeButton = GameObject.Find("Complete").gameObject;
        CompleteButtonScript = completeButton.GetComponent<QButtonScript>();

        //BUGS EXIST HERE

        //acceptButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("GameObject").transform.Find("Accept").gameObject;
        //acceptButtonScript = acceptButton.GetComponent<QButtonScript>();

        //giveUpButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("GameObject").transform.Find("GiveUp").gameObject;
        //giveUpButtonScript = giveUpButton.GetComponent<QButtonScript>();

        //completeButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("GameObject").transform.Find("Complete").gameObject;
        //CompleteButtonScript = completeButton.GetComponent<QButtonScript>();

        acceptButton.SetActive(false);
        giveUpButton.SetActive(false);
        completeButton.SetActive(false);

    }


    //SHOW ALL INFOS
    public void ShowAllInfos()
    {
        QuestUIManager.uiManager.ShowSelectedQuest(questID);

        //ACCEPT BUTTON
        if (QuestManager.questManager.RequestAvailableQuest(questID))
        {
            acceptButton.SetActive(true);
            acceptButtonScript.questID = questID;
        }
        else
        {
            acceptButton.SetActive(false);
        }

        //GIVE UP BUTTON
        if (QuestManager.questManager.RequestAcceptedQuest(questID))
        {
            giveUpButton.SetActive(true);
            giveUpButtonScript.questID = questID;
        }
        else
        {
            giveUpButton.SetActive(false);
        }

        //COMPLETED BUTTON
        if (QuestManager.questManager.RequestCompleteQuest(questID))
        {
            completeButton.SetActive(true);
            CompleteButtonScript.questID = questID;
        }
        else
        {
            completeButton.SetActive(false);
        }
    }

    public void AcceptQuest()
    {
        QuestManager.questManager.AcceptQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();

        //UPDATE ALL NPCS
        QuestObject[] currentQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach (QuestObject obj in currentQuestGuys)
        {
            //Set quest marker
        }
    }

    //GIVE UP QUEST
    public void GiveUpQuest()
    {
        QuestManager.questManager.AcceptQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();

        //UPDATE ALL NPCS
        QuestObject[] currentQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach (QuestObject obj in currentQuestGuys)
        {
            //Set quest marker
            obj.SetQuestMarker();
        }
    }

    //COMPLETE QUEST
    public void CompleteQuest()
    {
        QuestManager.questManager.AcceptQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();

        //UPDATE ALL NPCS
        QuestObject[] currentQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach (QuestObject obj in currentQuestGuys)
        {
            //Set quest marker
            obj.SetQuestMarker();
        }
    }

    public void ClosePanel()
    {
        QuestUIManager.uiManager.HideQuestPanel();
    }
}
