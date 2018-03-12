using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public static QuestManager questManager;

    //Master Quest list
    public List<Quest> questList = new List<Quest>();
    //Current Quest list
    public List<Quest> currentQuestList = new List<Quest>();

    //private vars for questObject


        void Awake()
    {
        if (questManager == null)
        {
            questManager = this;
        }

        else if (questManager != this)
        {
            Destroy(gameObject);

        }
        DontDestroyOnLoad(gameObject);

    }





    //AVALIABLE QUEST CHECK

    public void QuestRequest(QuestObject NPCQuestObject)
    {
        //Check for available quests
        if (NPCQuestObject.availableQuestIDs.Count > 0)
        {
            for (int i = 0; i < questList.Count; i++) //nested for to check avalible quest ID's int the quest list
            {
                for (int j = 0; j < NPCQuestObject.availableQuestIDs.Count; j++)
                {
                    if (questList[i].id == NPCQuestObject.availableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVALIABLE)
                    {
                        Debug.Log("Quest ID: " + NPCQuestObject.availableQuestIDs[j] + " " + questList[i].progress);

                        //tesing 
                        //AcceptQuest(NPCQuestObject.availableQuestIDs[j]);
                        QuestUIManager.uiManager.questAvaliable = true;
                        QuestUIManager.uiManager.avaliableQuests.Add(questList[i]);
                    }
                }
            }
        }
        //ACTIVE QUEST CHECK

        for (int i = 0; i < currentQuestList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.recievableQuestIDs.Count; j++)
            {
                if (currentQuestList[i].id == NPCQuestObject.recievableQuestIDs[j] && (currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED || currentQuestList[i].progress == Quest.QuestProgress.COMPLETED))
                {
                    Debug.Log("Quest ID: " + NPCQuestObject.recievableQuestIDs[j] + " is " + currentQuestList[i].progress);
                    //quest ui manager

                    //CompleteQuest(NPCQuestObject.recievableQuestIDs[j]);
                    QuestUIManager.uiManager.questRunning = true;
                    QuestUIManager.uiManager.activeQuests.Add(questList[i]);
                }
            }
        }


    }




    //Accept Quest

    public void AcceptQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVALIABLE)

            {
                currentQuestList.Add(questList[i]);
                questList[i].progress = Quest.QuestProgress.ACCEPTED;

            }
        }

    }

    //Give up quest

    public void GiveUpQuest(int questID)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if (currentQuestList[i].id == questID && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED)

            {
                currentQuestList[i].progress = Quest.QuestProgress.AVALIABLE;
                currentQuestList[i].questObjectiveCount = 0;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }

    }

    //Complete Quest

    public void CompleteQuest(int questID)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if (currentQuestList[i].id == questID && currentQuestList[i].progress == Quest.QuestProgress.COMPLETED)

            {
                currentQuestList[i].progress = Quest.QuestProgress.DONE;
                currentQuestList.Remove(currentQuestList[i]);

            }
        }

        //check for chain quests
        CheckChainQuest(questID);
    }


    //CHECK CHAIN QUEST
    void CheckChainQuest(int questID)
    {
        int tempID = 0;
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].nextQuest > 0)
            {
                tempID = questList[i].nextQuest;
            }
        }
        if (tempID > 0)
        {

            for (int i = 0; i < questList.Count; i++)
            {
                if (questList[i].id == tempID && questList[i].progress == Quest.QuestProgress.NOT_AVAILABLE)
                {
                    questList[i].progress = Quest.QuestProgress.AVALIABLE;
                }
            }

        }
    }




    //Add Items
    public void AddQuestItem(string questObjective, int itemAmount)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if (currentQuestList[i].questObjective == questObjective && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED)

            {
                //check the quest in proggress and quest item amount and increment
                currentQuestList[i].questObjectiveCount += itemAmount;
            }

            if (currentQuestList[i].questObjectiveCount >= currentQuestList[i].questObjectiveRequired && currentQuestList[i].progress == Quest.QuestProgress.COMPLETED)
            {
                currentQuestList[i].progress = Quest.QuestProgress.COMPLETED;
            }

        }
    }



   //Remove Items








    //Bool quest Available
    public bool RequestAvailableQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVALIABLE)

            {
                return true;
            }
        }
        return false;
    }

    //Bool quest Accepted
    public bool RequestAcceptedQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.ACCEPTED)

            {
                return true;
            }
        }
        return false;
    }

    //Bool quest Complete

    public bool RequestCompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.COMPLETED)

            {
                return true;
            }
        }
        return false;
    }

    //Other bools 

        //
    public bool checkForAvailableQuests(QuestObject NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.availableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.availableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVALIABLE)
                {
                    return true;
                }
            }
        }
        return false;
    }


    public bool checkForAcceptedQuests(QuestObject NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.recievableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.recievableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVALIABLE)
                {
                    return true;
                }
            }
        }
        return false;
    }


    public bool checkForCompletedQuests(QuestObject NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.recievableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.recievableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVALIABLE)
                {
                    return true;
                }
            }
        }
        return false;
    }


    //SHOW QUEST LOG 
    public void ShowQuestLog(int questID)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if (currentQuestList[i].id == questID)
            {
                QuestUIManager.uiManager.ShowQuestLog(currentQuestList[i]);

            }
        }
    }
}
