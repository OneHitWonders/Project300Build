using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour {

    //0.001388888889f rotateAround Value for 12 min rotation

    public float testAngle = 0f;
    private float rotationAngleDefault = 0.01388888889f;

    public bool useTestAngle = false;
	// Use this for initialization
	void Awake () {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {

        if (useTestAngle == true)
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.forward, testAngle);

        }
        else
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.forward, rotationAngleDefault);

        }
        gameObject.transform.LookAt(Vector3.zero);
	}
}
