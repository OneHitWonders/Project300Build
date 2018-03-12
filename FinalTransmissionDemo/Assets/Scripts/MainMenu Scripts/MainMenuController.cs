using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private SceneLoader sceneload;
    //private GameInstance instance;

    public Button btnPlay;
    public Button btnQuit;
    public Button btnDelete;
    // Use this for initialization

    void Start()
    {

        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");

        if (gameController != null)
        {
            sceneload = gameController.GetComponent<SceneLoader>();
            //instance = gameController.GetComponent<GameInstance>();

            btnPlay.onClick.AddListener(StartGame);
            btnDelete.onClick.AddListener(tut);

        }

    }


    private void StartGame()
    {
        SceneManager.LoadScene("OverviewMap");
    }

    public void tut()
    {
        SceneManager.LoadScene("TutorialScene");
        //instance.Quit();
    }

}
