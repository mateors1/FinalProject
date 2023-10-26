using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalNavigation : MonoBehaviour
{
    public Transform player;
    public Transform EndOflevel;
    Transform defaultPoint;
    NavMeshAgent agent;
    Transform currentTarget;


    private void OnEnable()
    {
        transform.position = defaultPoint.position;
    }

    void Start()

    {
        agent = GetComponent<NavMeshAgent>();
        currentTarget = player;
    }

    private void Update()
    {

        if (agent.remainingDistance < agent.stoppingDistance)
        {
            SwitchTarget();
        }
    }

    void SwitchTarget()
    {
        currentTarget = currentTarget == player ? EndOflevel : player;
    }



}
