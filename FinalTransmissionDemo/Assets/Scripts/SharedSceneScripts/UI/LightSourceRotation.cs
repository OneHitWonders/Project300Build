using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceRotation : MonoBehaviour {

    [SerializeField]
    private float rotationspeed;
	// Update is called once per frame
	void Update () {

        gameObject.transform.RotateAround(Vector3.zero, Vector3.right, rotationspeed * Time.deltaTime);
        gameObject.transform.LookAt(Vector3.zero);
	}
}
