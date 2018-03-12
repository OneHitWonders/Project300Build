using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchBuilding : MonoBehaviour {

    private ResourceManager resManager;

    private SurvivorController survController;
    private GameObject survivorOutside;

    [SerializeField]
    private GameObject interactingPanel;

    [SerializeField]
    private int BuildingSize =1 ;


    //Variables for Searching
    private bool canSearch = false;
    private bool beingSearched = false;
    private DayTime dayTime;
    private float HrFinishSearch = 0;

    private bool BeenSearched = false;

    private void Awake()
    {
        interactingPanel = GameObject.Find("interactPanel");

    }

    // Use this for initialization
    void Start () {
        survController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SurvivorController>();
        dayTime = GameObject.FindGameObjectWithTag("GameController").GetComponent<DayTime>();
        resManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ResourceManager>();

        interactingPanel.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if ((canSearch == true) && BeenSearched == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                BeginBuildingSearch();
            }
        }

        //When Search Timer Ends
        if (beingSearched == true)
        {
            if (HrFinishSearch == dayTime.hour)
            {
                FinishedSearch();
            }
        }
	}


    public void BeginBuildingSearch()
    {
        survivorOutside.SetActive(false);
        beingSearched = true;
        HrFinishSearch = dayTime.hour + 1; // what time the survivor returns from searching
        interactingPanel.SetActive(false);

        Debug.Log(HrFinishSearch.ToString());
    }

    private void FinishedSearch()
    {
        beingSearched = false;
        BeenSearched = true; // prevents re-searching
        survivorOutside.SetActive(true);
        GenerateResourcesGathered();
        resManager.ResourcesGenerated();

    }

    public void GenerateResourcesGathered()
    {
        //Food
        if (Random.Range(0,20) <= 18)
        {
            resManager.rCollector.foodCollected += (2 * BuildingSize) + 2;

        }
        //Water
        if (Random.Range(0, 20) <= 14)
        {
            resManager.rCollector.waterCollected += (3 * BuildingSize) + 2;

        }
        //Wood
        if (Random.Range(0, 20) <= 14)
        {
            resManager.rCollector.woodCollected += (3 * BuildingSize) + 2;

        }
        //Metal
        if (Random.Range(0, 20) <= 8)
        {
            resManager.rCollector.metalCollected += (2 * BuildingSize) + 2;

        }

        //medicine
        if (Random.Range(0, 20) <= 4)
        {
            resManager.rCollector.medsCollected += (1 * BuildingSize)+2;

        }

        //Ammo
        if (Random.Range(0, 20) <= 5)
        {
            resManager.rCollector.ammoCollected += (3 * BuildingSize);

        }
        //Money
        if (Random.Range(0, 20) <= 10)
        {
            resManager.rCollector.moneyCollected += (2 * BuildingSize) + 2;

        }

    }




    private void OnTriggerEnter(Collider other)
    {
        if (BeenSearched == false)
        {
            if ((other.gameObject.tag == "Survivor") && beingSearched == false)
            {
                survivorOutside = other.gameObject;
                canSearch = true;
                Debug.Log("Can search");
                interactingPanel.SetActive(true);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
            if ((other.tag == "Survivor")&& beingSearched == false)
            {

                survivorOutside = null;
                canSearch = false;
            Debug.Log("TriggerLeave");
            interactingPanel.SetActive(false);

        }


    }






}
