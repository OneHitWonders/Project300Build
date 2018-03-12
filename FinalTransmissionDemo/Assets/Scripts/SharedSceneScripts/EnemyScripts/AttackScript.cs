using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackScript : MonoBehaviour {

    private NavMeshAgent navAgent;





	// Use this for initialization
	void Awake () {
        navAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}//end class
