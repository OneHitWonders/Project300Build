using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour {

    //Note this script requires DayTime Script
    [SerializeField]
    private DayTime daytime;


    public int enemyNo;
    public int AttackChance = 5;

    //used for spawning
    [HideInInspector]
    public bool attackingcoming = false;
    public float hrOfDay = 0;


    int LevelAggression =0;

    public GameObject enemyPrefab;
    public GameObject initialSpawnPoint;


    public void CalculateAttackChance()
    {
        int tempGen = Random.Range(45,60);
        if ((tempGen + AttackChance) >= 80)
        {
            Debug.Log("Successful");
            attackingcoming = true;
            hrOfDay = Random.Range(13,18);
        }

    }

    private void FixedUpdate()
    {
        if ((hrOfDay == daytime.hour) && attackingcoming ==true)
        {
            Debug.Log("Spawning Beginning");
            DetermineAttack();
            AttackChance = 0; // reset after wave spawn begins
            hrOfDay = 0;
            attackingcoming = false;
        }
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


    public void GenerateAttackGroup(int NumberOfEnemies )
    {
        Vector3 spawnPosDistance = new Vector3(0, 0, 0);
        for (int i = 0; i < NumberOfEnemies; i++)
        {
            spawnPosDistance.z += enemyPrefab.transform.localScale.z * 1.5f;
            Instantiate(enemyPrefab, initialSpawnPoint.transform.position + spawnPosDistance, enemyPrefab.transform.rotation);
        }
    }


}//end script
