using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnabler : MonoBehaviour {


    List<GameObject> AreObjects = new List<GameObject>();

    Transform[] ts;


	// Use this for initialization
	void Start () {
     
        ts = gameObject.GetComponentsInChildren<Transform>();



    }
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Survivor")
        {
            foreach (Transform item in ts)
            {
               
                    item.gameObject.SetActive(true);
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Survivor")
        {
            foreach (Transform item in ts)
            {
                if (item.gameObject != this.gameObject)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    }


}
