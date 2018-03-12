using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceManager : MonoBehaviour {

    #region TextAndValues

    public int Food;
    public Text foodText;

    public int Water;
    public Text waterText;

    public int Wood;
    public Text woodText;

    public int Metal;
    public Text metalText;

    public int Medicine;
    public Text medicineText;

    public int Happiness;
    public Text happinessText;

    public int Ammo;
    public Text ammoText;

    public int Money;
    public Text moneyText;

    //toDisable/Enable
    public GameObject gatheredtext;
    public Text gathertext;
    private bool fadeAwayGatherText;

    #endregion

    [HideInInspector]
    public ResourceCollector rCollector;



    // Use this for initialization
    void Start() {

        rCollector = GetComponent<ResourceCollector>();

        foodText = GameObject.Find("FoodText").GetComponent<Text>();
        waterText = GameObject.Find("WaterText").GetComponent<Text>();
        woodText = GameObject.Find("WoodText").GetComponent<Text>();
        metalText = GameObject.Find("MetalText").GetComponent<Text>();
        medicineText = GameObject.Find("MedicineText").GetComponent<Text>();
        happinessText = GameObject.Find("HappinessText").GetComponent<Text>();
        ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();

        Ammo = 20;
        updateUiInfo();
        gatheredtext = GameObject.Find("gatheredText");
        gathertext = gatheredtext.GetComponent<Text>();

     

    }
    private void FixedUpdate()
    {
        if (fadeAwayGatherText == true)
        {
            StopCoroutine("ShowCollected");
        }
    }

    public void ResourcesGenerated()
    {
        Food += rCollector.foodCollected;
        Water += rCollector.waterCollected;
        Wood += rCollector.woodCollected;
        Metal += rCollector.metalCollected;
        Medicine += rCollector.medsCollected;
        Ammo += rCollector.ammoCollected;
        Money += rCollector.moneyCollected;

        gathertext.text = 
            "Food +" +rCollector.foodCollected 
            + " water +" + rCollector.waterCollected
            + " wood +" + rCollector.woodCollected
            + " Metal +" + rCollector.metalCollected
            + " Medicine +" + rCollector.medsCollected
            + " Ammo +" + rCollector.ammoCollected
            + " Money +" + rCollector.moneyCollected
            ;
        clearCollector();

        StartCoroutine("ShowCollected");
        updateUiInfo();

    }

    public void clearCollector()
    {
        rCollector.foodCollected = 0;
        rCollector.waterCollected = 0;
        rCollector.woodCollected = 0;
        rCollector.metalCollected = 0;
        rCollector.metalCollected = 0;
        rCollector.ammoCollected = 0;
        rCollector.moneyCollected = 0;
    }
   
    public void updateUiInfo()
    {
        foodText.text = "Food: " + Food.ToString();
        waterText.text = "Water: " + Water.ToString();
        woodText.text = "Wood: " + Wood.ToString();
        metalText.text = "Metal: " + Metal.ToString();
        medicineText.text = "Medicine: " + Medicine.ToString();
        ammoText.text = "Ammo: " + Ammo.ToString();
        moneyText.text = "Money: " + Money.ToString();



    }

    private IEnumerator ShowCollected()
    {
        fadeAwayGatherText = false;
        gatheredtext.SetActive(true);
        yield return new WaitForSeconds(4f);
        fadeAwayGatherText = true;
        gatheredtext.SetActive(false);

    }




}
