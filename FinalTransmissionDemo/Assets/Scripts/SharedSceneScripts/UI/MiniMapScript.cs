using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour {


    private GameObject player;
    private Vector3 playerPos;

    private SurvivorController Controller;

	// Use this for initialization
	void Start () {
        Controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<SurvivorController>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (player != Controller.selectedSurvivor)
        {
            player = Controller.selectedSurvivor;
        }

        gameObject.transform.position = new Vector3(player.transform.position.x, 90, player.transform.position.z);

	}
}
