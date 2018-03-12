using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject tutorialObject;

	// Use this for initialization
	void Start () {
        tutorialObject.SetActive(false);
	}

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Survivor")
        {
            tutorialObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }


    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(15);
        Destroy(tutorialObject);
        Destroy(gameObject);

    }


}
