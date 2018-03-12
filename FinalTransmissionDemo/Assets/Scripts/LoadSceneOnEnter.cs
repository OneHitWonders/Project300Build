using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnEnter : MonoBehaviour {

    public GameObject guiObject;
    public string levelToLoad;
    //use this for initialization
    void Start ()
    {
        guiObject.SetActive(false);

    }

    //this is called once per frame
    void OnTriggerStay (Collider other)
    {
        if(other.gameObject.tag == "Survivor")
        {
            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
            {
                Application.LoadLevel(levelToLoad);
            }
        }
    }
    void OnTriggerExit()
    {
        guiObject.SetActive(false);
    }
}
