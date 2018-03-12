using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Quest
{
    //Different stages of quests
	public enum QuestProgress
    {
        NOT_AVAILABLE,
        AVALIABLE,
        ACCEPTED,
        COMPLETED,
        DONE
    }



    //Title of quest
    public string title;
    //Quest ID to locate what quest is active
    public int id;
    //enum Sate
    public QuestProgress progress;
    //string for the quest giver/reciever
    public string description;
    //quest giver hint from radio post
    public string hint;
    //string
    public string congratulation;
    //quest summary
    public string summary;
    //next quest
    public int nextQuest;

    public string questObjective; //name of quest objective
    public int questObjectiveCount; //Number of quest Objectives
    public int questObjectiveRequired; //amount required for quest

    public int expReward;
    public int ConstructionSupplyReward;
    public string itemReward;
}
