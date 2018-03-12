using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenerateSurvivorUI : MonoBehaviour {

    public List<Image> SurvivorTabs = new List<Image>();


    public Image survUIPrefab;


    public SurvivorController survControl;

    void Start()
    {
        survControl = 
            GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<SurvivorController>();

    
    }


    public void ButtonPress()
    {
        Debug.Log("pressed");
    }



    public void createNewSurvivorTab()
    {

        for (int i = 0; i < survControl.searchingSurvivors.Count; i++)
        {

        }
        Instantiate(survUIPrefab, new Vector3(survUIPrefab.transform.position.x, survUIPrefab.transform.position.y + 20, 1 ), survUIPrefab.transform.rotation);


    }

   

}
