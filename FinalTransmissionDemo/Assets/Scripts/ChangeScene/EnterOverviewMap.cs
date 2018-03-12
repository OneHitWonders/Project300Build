 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterOverviewMap : MonoBehaviour {
    // Use this for initialization    
    void Start ()
    {              }
    // Update is called once per frame    
    void Update ()
    {              }

    void OnTriggerEnter (Collider  other)
    {
        //tag your player "Player"       
        if (GetComponent<Collider>().tag == "Survivor")
        {
            //"scene" this is a name of level to load      
            SceneManager.LoadScene("OverviewMap");
        }
    }
}﻿