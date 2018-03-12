using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject ObjectToMoveTo;
    private Mover mover;
    bool canMove = true;
    public float shotRate = 3f;
    private float shotCount = 0f;
    public Transform target;
    public float range;
    float distance;
    public int health = 100;


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
        mover = GetComponent<Mover>();
        ObjectToMoveTo = GameObject.FindGameObjectWithTag("Survivor");
        target = ObjectToMoveTo.transform;
    }

    void Update()
    {

        distance = Vector3.Distance(transform.position, target.position);

        if (distance < range)
        {
            if (distance < 50)
            {
                mover.speed = 0f;
                transform.LookAt(target);

                if (shotCount <= 0f)
                {

                    Fire();
                    shotCount = 10f / shotRate;
                }

                shotCount -= Time.deltaTime;
            }

            else if (distance > 50)
            {
                mover.speed = 15f;
                mover.MoveTo(ObjectToMoveTo);
            }

            if (health <= 0)
            {
                Destroy(gameObject);
            }


        }

    }


    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Dying();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Survivor")
        {
            mover.Stop();
            canMove = false;
            health = health - (Random.Range(3, 6));

            if (health <= 0)
            {
                Dying();
            }
        }
        else if (other.gameObject.tag == "Node")
        {
            var node = other.gameObject.GetComponent<PathNode>();

            if (node.NextNode != null)
            {
                ObjectToMoveTo = node.NextNode.gameObject;
            }
            else
                canMove = false;
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
            Update();
        }
    }

    public void Fire()
    {
        // Will create the bullet
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        //GameObject target = GameObject.FindGameObjectWithTag("Player");

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100;

        // Destroys the bullet after two seconds
        Destroy(bullet, 2.0f);
    }

    public void Dying()
    {
        int CAble = Random.Range(0,2);

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
