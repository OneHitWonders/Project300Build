using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionCollect : MonoBehaviour {


    private ResourceManager rmanager;

    // Use this for initialization
    void Start()
    {
        rmanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ResourceManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Survivor")
        {
            rmanager.Wood += 2;
            rmanager.Metal += 2;
            rmanager.updateUiInfo();
            Destroy(gameObject);//remove crate
        }

    }
}
