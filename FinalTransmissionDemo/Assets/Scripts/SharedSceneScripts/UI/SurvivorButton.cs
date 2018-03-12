using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorButton : MonoBehaviour {

    [SerializeField]
    private int BtnID;
    private GameObject BtnSurvivor;

    SurvivorController survController;

    private void Awake()
    {
        survController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SurvivorController>();
        foreach (GameObject surv in survController.listOfSurvivors)
        {
            Survivor tempsurv = surv.GetComponent<Survivor>();
            if (tempsurv.SurvivorID == BtnID)
            {
                BtnSurvivor = surv;
                Debug.Log(BtnSurvivor.name);
            }
        }


    }//end Awake


    public void OnButtonClicked()
    {
        //insert get player ID
        if (survController.selectedSurvivor != BtnSurvivor && BtnSurvivor != null)
        {
            survController.selectedSurvivor = BtnSurvivor;

        }


    }//end OnButtonClicked



}




