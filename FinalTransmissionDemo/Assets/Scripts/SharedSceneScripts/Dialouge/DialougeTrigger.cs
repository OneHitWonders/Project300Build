using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour {

    public Dialouge dialouge;

    public void TriggerDialouge (Dialouge t)
    {

        FindObjectOfType<DialougeManager>().StartDialogue(t);

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.tag == "NPC")
                {                
                    Dialouge trig = hit.collider.gameObject.GetComponent<Dialouge>();
                    Debug.Log("NPC hit");
                    
                    TriggerDialouge(trig);
                }

            }
        }

    }
}
