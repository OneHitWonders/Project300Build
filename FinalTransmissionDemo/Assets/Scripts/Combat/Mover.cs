using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Mover : MonoBehaviour
{

    private NavMeshAgent agent;
    public float speed = 15.0f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public void MoveTo(GameObject target)
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        MoveTo(target.transform.position + movement);
    }

    public void Stop()
    {
        agent.isStopped = true;
    }

}

