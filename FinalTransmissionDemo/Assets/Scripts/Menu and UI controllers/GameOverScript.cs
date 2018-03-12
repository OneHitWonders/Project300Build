using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    public bool playerDied;

    #region GameOverUI

    public GameObject deathPanel;
    public Text deathText;
    public Button menuButton;
    public Button quitButton;

    #endregion




    // Use this for initialization
    void Start () {



        deathPanel = GameObject.Find("GameOverPanel");
        deathText = deathPanel.GetComponentInChildren<Text>();
        //deathText = GameObject.Find("deadText").GetComponent<Text>();
        menuButton = GameObject.Find("mainmenuBTN").GetComponent<Button>();
        quitButton = GameObject.Find("quitBTN").GetComponent<Button>();

        deathPanel.SetActive(false);



    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnPlayerDeath()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0f;
    }


}
