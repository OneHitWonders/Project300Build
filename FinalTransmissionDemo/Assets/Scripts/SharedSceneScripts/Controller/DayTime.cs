using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayTime : MonoBehaviour {

    //Note this script requires AttackBase Script

    #region BaseSceneSpecific
    Scene currentScene;
    [SerializeField]
    private BaseEvents baseevents;

    #endregion


    public Text DayText;
    public Text HourText;

    [SerializeField]
    private float newDayHour; // Hour a newDay Starts

    private float lastChange; //Used to compare time to determine if an hour passed
    public float day = 1;
    public float hour = 12;
    private int enableValue = 0;
    private string ampm = "PM";
    public float timeChange = 30; //  seconds before hour changes


    public bool baseAttack = false;
    public bool baseTrader = false;


	// Use this for initialization
	void Start () {
        //      timeText.text = "Day: " + day.ToString() + "  " + hour.ToString() + " " + ampm;
        DayText = GameObject.FindGameObjectWithTag("DayText").GetComponent<Text>();
        HourText = GameObject.FindGameObjectWithTag("HourText").GetComponent<Text>();


        DayText.text = "Day: " + day.ToString();
        HourText.text = hour.ToString() +ampm;
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update () {

        //Calculates Time
        if ((Time.time - lastChange) > timeChange)
        {
            hour++;
            // changes to PM
            if (hour == 12)
            {
                ampm = "PM";
            }

            //Changes to Am and resets clock
            if (hour == 24)
            {
                day++;
                hour = 0;
                ampm = "AM";
                DayText.text = "Day: " + day.ToString();
            }
            lastChange = Time.time; // Updated each frame, current time
        }//end if


        //Used to determine if a new day or not
        if (hour == newDayHour && enableValue == 0)
        {
            NewDay();
        }
        if (hour == (newDayHour + 1))
        {
            enableValue = 0; // reset method call so it can be recalled the folow day
        }
        HourText.text = hour.ToString() + ampm;

    }//end Update


    void NewDay()
    {
        enableValue = 1; // quickly resets to stop constant Method Calling
        if (currentScene.name == "BaseScene")
        {
            baseevents.AttackChance += 5;
            baseevents.GenerateChanceOfEvent(); // Determines if attack happens that day

        }
        Debug.Log("New Day");

        //deducte resources

    }

    


}//endclass
