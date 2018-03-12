using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour {

    public List<int> availableQuestIDs = new List<int>();

    public List<int> recievableQuestIDs = new List<int>();

    public GameObject questMarker;
    public Image theImage;

    public Sprite questAvaliableSprite;
    public Sprite questReceivableSprite;

    private bool inTrigger;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Survivor")
        {
            inTrigger = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Survivor")
        {
            inTrigger = false;
        }
    }

    // Use this for initialization
    void Start () {
        SetQuestMarker();
		
	}


    public void SetQuestMarker()
    {
        if (QuestManager.questManager.checkForCompletedQuests(this))

        {
            questMarker.SetActive(true);
            theImage.sprite = questAvaliableSprite;
           
        }
        else if (QuestManager.questManager.checkForAvailableQuests(this))

        {
            questMarker.SetActive(true);
            theImage.sprite = questReceivableSprite;

        }
        else
        {
            questMarker.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (inTrigger && Input.GetKeyDown(KeyCode.Space))
        {

            //QuestManager.questManager.QuestRequest(this);
            //quest UI manager
            QuestUIManager.uiManager.CheckQuests(this);
        }
	}
}
