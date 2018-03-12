using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverviewMapController : MonoBehaviour
{
    //create a game instance in future build
    private SceneLoader sceneload;

    public Button HomeBtn;
    public Button RiverdaleBtn;
    public Button MansionBtn;



    // Use this for initialization
    void Awake()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");

        if (gameController != null)
        {

            sceneload = gameController.GetComponent<SceneLoader>();

            RiverdaleBtn.onClick.AddListener(LoadRiverdale);
            HomeBtn.onClick.AddListener(LoadHomeBase);
            MansionBtn.onClick.AddListener(LoadMansion);


        }

    }

    // load areas on the map.
    private void LoadRiverdale()
    {
        SceneManager.LoadScene("TownScene");
    }

    private void LoadHomeBase()
    {
        SceneManager.LoadScene("BaseScene");
    }

    private void LoadMansion()
    {

        SceneManager.LoadScene("Riverdale Mansion");

    }



}

