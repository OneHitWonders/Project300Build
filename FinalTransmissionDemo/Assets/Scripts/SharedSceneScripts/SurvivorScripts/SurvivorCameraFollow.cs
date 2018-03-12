using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorCameraFollow : MonoBehaviour {


    public SurvivorController controller;
    public GameObject targetToFollow;

    [SerializeField]
    private float Offset_X;
    [SerializeField]
    private float Offset_Y;
    [SerializeField]
    private float Offset_Z;


    private float cameraoffX;
    private float cameraoffY;
    private float cameraoffZ;




    private int rotateCounter=1;


    // Use this for initialization
    void Awake () {

        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<SurvivorController>();

	}

    void Start()
    {
        targetToFollow = controller.selectedSurvivor;

        cameraoffX = Offset_X;
        cameraoffY = Offset_Y;
        cameraoffZ = Offset_Z;
    }
    // Update is called once per frame
    void Update ()
    {
        if (targetToFollow != null)
        {
            targetToFollow = controller.selectedSurvivor;

        }
        //updates when you change character selected
        if (targetToFollow != controller.selectedSurvivor)
        {

            targetToFollow = controller.selectedSurvivor;

        }

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    rotateCamera();

        //}

    }

    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(targetToFollow.transform.position.x + cameraoffX, targetToFollow.transform.position.y + cameraoffY, targetToFollow.transform.position.z + cameraoffZ);
        gameObject.transform.LookAt(targetToFollow.transform);
    }

    public void rotateCamera()
    {
        Debug.Log("rotCalled");

        rotateCounter++;
        if (rotateCounter == 1)
        {
            cameraoffX = -60;
            cameraoffY = 65;
            cameraoffZ = 60;

            Debug.Log(gameObject.transform);

        }
        else if (rotateCounter == 2)
        {
            cameraoffX = 60;
            cameraoffY = 65;
            cameraoffZ = 60;


        }

        else if (rotateCounter == 3)
        {
            cameraoffX = 60;
            cameraoffY = 65;
            cameraoffZ = -60;

        }

        else if (rotateCounter == 4)
        {
            cameraoffX = -60;
            cameraoffY = 65;
            cameraoffZ = -60;

            rotateCounter = 0;
        }
        controller.UpdateCameraAngle();
    }


}//end class
