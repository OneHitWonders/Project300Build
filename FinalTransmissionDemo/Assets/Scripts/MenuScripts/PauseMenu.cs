using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private GameObject pausepanel;
    [HideInInspector]
    public bool IsGamePaused = false;



	// Use this for initialization
	void Start () {
        pausepanel = GameObject.Find("PausePanel");
        pausepanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused == true)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }

	}

    public void Resume()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }


    void Pause()
    {
        pausepanel.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;

    }

    public void MainMenu()
    {
        Debug.Log("Loading menu");
        SceneManager.LoadScene("mainmenu");
    }



    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();

    }



}
