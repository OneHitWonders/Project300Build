using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEvents : MonoBehaviour {

    private DayTime daytime;


    //TraderEvent Variables
    private bool traderIncoming = false;
    private float hrToLeave = 0;
    public GameObject traderPrefab;



    //AttackEvent Variables
    private int enemyNo; // Number of enemies to spawn
    [HideInInspector]
    public int AttackChance = 5;
    [HideInInspector]
    public bool attackingcoming = false;
    int LevelAggression = 0;
    public GameObject enemyPrefab;


    //used in all events
    private float hrOfDay = 0; // timeEventOccurs
    public GameObject initialSpawnPoint;
    private int eventchance;


    // Use this for initialization
    void Start () {
        daytime = GameObject.FindGameObjectWithTag("GameController").GetComponent<DayTime>();
	}
	
	// Update is called once per frame
    public void GenerateChanceOfEvent()
    {
        eventchance = Random.Range(0,125);


        if ((eventchance + AttackChance) > 150)
        {
            CalculateAttack();
        }

        else if (eventchance > 49 && eventchance < 76)
        {
            TraderEvent();
        }

        else if (eventchance > 75  && eventchance < 100)
        {
            SurvivorEvent();
        }


     

    }

    private void FixedUpdate()
    {
        if ((hrOfDay == daytime.hour) && attackingcoming == true)
        {
            Debug.Log("Spawning Beginning");
            DetermineAttack();
            AttackChance = 5; // reset after wave spawn begins
            hrOfDay = 0;
            attackingcoming = false;
        }
        else if ((hrOfDay == daytime.hour) && traderIncoming == true)
        {
            




        }


    }

    #region Trade Events

    public void TraderEvent()
    {
        traderIncoming = true;
        hrOfDay = Random.Range(13, 18); // Generate hour of Event
        hrToLeave = hrOfDay += 2;

    }

    public void SpawnTrader()
    {
        Instantiate(traderPrefab, initialSpawnPoint.transform.position, traderPrefab.transform.rotation);

    }


    #endregion

    #region Survivor Events
    public void SurvivorEvent()
    {
        hrOfDay = Random.Range(10, 18); // Generate hour of Event


    }
    #endregion

    #region Base Attacks

    public void CalculateAttack()
    {
        
      
            Debug.Log("Attack Generated");
            attackingcoming = true;
            hrOfDay = Random.Range(13, 18); // Generate hour of Event
        

    }

    public void DetermineAttack()
    {
        switch (LevelAggression)
        {
            case 0:
                enemyNo = 4;
                GenerateAttackGroup(enemyNo);
                Debug.Log(enemyNo);
                break;


            case 1:
                enemyNo = Random.Range(4, 7);
                GenerateAttackGroup(enemyNo);
                Debug.Log(enemyNo);
                break;

            case 2:
                enemyNo = Random.Range(6, 10);
                GenerateAttackGroup(enemyNo);
                Debug.Log(enemyNo);
                break;

            case 3:
                enemyNo = Random.Range(9, 12);
                GenerateAttackGroup(enemyNo);
                Debug.Log(enemyNo);
                break;

            case 4:
                enemyNo = Random.Range(11, 14);
                GenerateAttackGroup(enemyNo);
                Debug.Log(enemyNo);
                break;
        }
    }


    public void GenerateAttackGroup(int NumberOfEnemies)
    {
        Vector3 spawnPosDistance = new Vector3(0, 0, 0);
        for (int i = 0; i < NumberOfEnemies; i++)
        {
            spawnPosDistance.z += enemyPrefab.transform.localScale.z * 1.5f;
            Instantiate(enemyPrefab, initialSpawnPoint.transform.position + spawnPosDistance, enemyPrefab.transform.rotation);
        }
    }


    #endregion region


}
