using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedBox : MonoBehaviour {

    public GameObject debris;
	void OnMouseDown()
    {
        Instantiate(debris, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
