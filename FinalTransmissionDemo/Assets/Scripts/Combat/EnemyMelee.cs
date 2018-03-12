using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{

    public GameObject ObjectToMoveTo;
    private Mover mover;
    bool canMove = true;
    public Transform target;
    public float range;
    public float distance;
    public int health = 100;
    public float speed = 5.0f;


    #region Collectables
    [SerializeField]
    private GameObject collectableCon;
    [SerializeField]
    private GameObject collectableAmmo;
    [SerializeField]
    private GameObject collectableMed;


    #endregion


    void Start()
    {
        mover = gameObject.GetComponent<Mover>();
        ObjectToMoveTo = GameObject.FindGameObjectWithTag("Survivor");
        target = ObjectToMoveTo.transform;
    }

    void Update()
    {

        distance = Vector3.Distance(transform.position, target.position);

        if (distance < range)

            if (canMove)
                mover.MoveTo(ObjectToMoveTo);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Survivor")
        {
            health = health - (Random.Range(12, 18));

            if (health <= 0)
            {
                Dying();
            }
        }

        if (other.gameObject.tag == "Bullet")
        {
            health = health - 50;
            if (health == 0)
            {
                Dying();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Survivor")
        {
            canMove = true;

        }
    }

    public void Dying()
    {
        int CAble = Random.Range(0, 2);

        switch (CAble)
        {
            case 0:
                Instantiate(collectableCon, gameObject.transform.position, gameObject.transform.rotation);
                break;
            case 1:
                Instantiate(collectableMed, gameObject.transform.position, gameObject.transform.rotation);
                break;
            case 2:
                Instantiate(collectableAmmo, gameObject.transform.position, gameObject.transform.rotation);
                break;
        }


        GameObject.Destroy(gameObject);
    }



}