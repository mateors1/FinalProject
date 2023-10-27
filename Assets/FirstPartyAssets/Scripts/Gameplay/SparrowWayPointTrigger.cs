using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SparrowWayPointTrigger : MonoBehaviour
{
    public Transform player;
    public Transform EndOflevel;
    Vector3 defaultPoint;
    NavMeshAgent agent;
    Transform currentTarget;


    private void OnEnable()
    {
        transform.position = EndOflevel.position;
    }

    void Start()

    {
        defaultPoint = transform.position;
        agent = GetComponent<NavMeshAgent>();
        currentTarget = player;
    }

    private void Update()
    {

        if (agent.remainingDistance < agent.stoppingDistance)
        {
            SwitchTarget();
        }
        agent.SetDestination(currentTarget.position);
    }

    void SwitchTarget()
    {
        currentTarget = currentTarget == player ? EndOflevel : player;
    }



}