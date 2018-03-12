using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseOverButton : MonoBehaviour, IPointerEnterHandler
{

    public Button Mansion;
    public Text SearrchingHours;
    public bool mouseover = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
      
    }
}
