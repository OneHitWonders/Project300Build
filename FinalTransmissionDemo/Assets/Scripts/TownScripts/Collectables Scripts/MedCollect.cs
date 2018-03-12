using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedCollect : MonoBehaviour {


    // Use this for initialization
    void Start()
    {

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

            if (other.gameObject.GetComponent<Survivor>().Health < 100)
            {
                other.gameObject.GetComponent<Survivor>().Health += 15;
                if (other.gameObject.GetComponent<Survivor>().Health > 100)
                {
                    other.gameObject.GetComponent<Survivor>().Health = 100;

                }
                Destroy(gameObject);

            }

        }

    }
}
