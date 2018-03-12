using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseTabButtons : MonoBehaviour {

    public bool survivorTabOpen = false;
    public bool BuildTabOpen = false;
    public bool ResourcesTabOpen = false;
    public bool RadioTabOpen = false;
    public bool MissionsTabOpen = false;

    public Image SurvivorTabWindow;
    public Image BuildTabWindow;
    public Image ResourceTabWindow;
    public Image RadioTabWindow;
    public Image MissonsTabWindow;

    List<Image> ImageWindowList = new List<Image>();


    private void Awake()
    {
      
      SurvivorTabWindow.gameObject.SetActive(false);
      BuildTabWindow.gameObject.SetActive(false); 
      ResourceTabWindow.gameObject.SetActive(false); 
      RadioTabWindow.gameObject.SetActive(false); 
      MissonsTabWindow.gameObject.SetActive(false); 
}


    public void OpenPanelsurvivorTab()
    {

        BuildTabWindow.gameObject.SetActive(false);
        ResourceTabWindow.gameObject.SetActive(false);
        RadioTabWindow.gameObject.SetActive(false);
        MissonsTabWindow.gameObject.SetActive(false);

        if (survivorTabOpen == false)
        {
            SurvivorTabWindow.gameObject.SetActive(true);
            survivorTabOpen = true;
        }
        else
        {
            SurvivorTabWindow.gameObject.SetActive(false);
            survivorTabOpen = false;
        }

        

    }


    public void OpenPanelBuildTab()
    {
        SurvivorTabWindow.gameObject.SetActive(false);
        ResourceTabWindow.gameObject.SetActive(false);
        RadioTabWindow.gameObject.SetActive(false);
        MissonsTabWindow.gameObject.SetActive(false);


        if (survivorTabOpen == false)
        {
            BuildTabWindow.gameObject.SetActive(true);
            survivorTabOpen = true;
        }
        else
        {
            BuildTabWindow.gameObject.SetActive(false);
            survivorTabOpen = false;
        }


    }


    public void OpenPanelResourcesTab()
    {
        SurvivorTabWindow.gameObject.SetActive(false);
        BuildTabWindow.gameObject.SetActive(false);
        RadioTabWindow.gameObject.SetActive(false);
        MissonsTabWindow.gameObject.SetActive(false);



        if (ResourcesTabOpen == false)
        {
            ResourceTabWindow.gameObject.SetActive(true);
            ResourcesTabOpen = true;

        }
        else
        {
            ResourceTabWindow.gameObject.SetActive(false);
            ResourcesTabOpen = false;
        }

    }

    public void OpenPanelRadioTab()
    {
        SurvivorTabWindow.gameObject.SetActive(false);
        BuildTabWindow.gameObject.SetActive(false);
        ResourceTabWindow.gameObject.SetActive(false);
        MissonsTabWindow.gameObject.SetActive(false);



        if (RadioTabOpen == false)
        {
            RadioTabWindow.gameObject.SetActive(true);
            RadioTabOpen = true;
        }
        else
        {
            RadioTabWindow.gameObject.SetActive(false);
            RadioTabOpen = false;
        }


    }

    public void OpenPanelMissionsTab()
    {
        SurvivorTabWindow.gameObject.SetActive(false);
        BuildTabWindow.gameObject.SetActive(false);
        ResourceTabWindow.gameObject.SetActive(false);
        RadioTabWindow.gameObject.SetActive(false);


        if (MissionsTabOpen == false)
        {
            MissonsTabWindow.gameObject.SetActive(true);
            MissionsTabOpen = true;
        }
        else
        {
            Debug.Log("error");
            MissonsTabWindow.gameObject.SetActive(false);
            MissionsTabOpen = false;
        }


    }




}//end class
