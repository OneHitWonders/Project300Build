using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TravelGUI : MonoBehaviour
{

    [SerializeField] private Image travelImage;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Survivor"))
        {
            travelImage.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Survivor"))
        {
            travelImage.enabled = false;
        }
    }
}
