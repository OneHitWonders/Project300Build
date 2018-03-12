using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorMovement : MonoBehaviour {

    [HideInInspector]
    public Rigidbody survivorBody;
    public SurvivorController controller;

    public bool Testing = false;

    #region Movement
    //MovementVariables
    public float walkSpeed = 5f;
    public float walkingSnap = 50f;
    public float turningSmoothing = 0.5f;


 
    public Vector3 movementDirection;

    //Camera Variables
    public float offset_X;
    public float offset_Y;
    public float offset_Z;
    Camera main;

    public bool isSelected= false;

    #endregion



    // Use this for initialization
    void Awake () {
        survivorBody = gameObject.GetComponent<Rigidbody>();
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<SurvivorController>();
    }

    // Update is called once per frame
    void Update () {

        if (movementDirection.sqrMagnitude > 1)
        {
            movementDirection.Normalize();
        }
    }


    void FixedUpdate()
    {
        if (isSelected == true)
        {
            Vector3 targetVelocity = movementDirection * walkSpeed;
            Vector3 deltaVelocity = targetVelocity - survivorBody.velocity;
            survivorBody.AddForce(deltaVelocity * walkingSnap, ForceMode.Acceleration);


            Vector3 faceDirection = movementDirection;

            if (faceDirection == Vector3.zero)
            {
                survivorBody.angularVelocity = Vector3.zero;
            }
            else
            {
                float rotationAngle = AngleAroundAxis(transform.forward, faceDirection, Vector3.up);
                survivorBody.angularVelocity = (Vector3.up * rotationAngle * turningSmoothing);
            }

        }

        if (Testing == false)
        {
            if ((controller.selectedSurvivor != gameObject) && (isSelected == true))
            {
                isSelected = false;
                Debug.Log("no longer true");
            }
        }
     
       

    }

    float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
    {
        dirA = dirA - Vector3.Project(dirA, axis);
        dirB = dirB - Vector3.Project(dirB, axis);

        float angle = Vector3.Angle(dirA, dirB);


        return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);
    }
}
