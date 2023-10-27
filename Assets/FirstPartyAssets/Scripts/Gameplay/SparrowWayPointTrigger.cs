using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class SparrowWayPointTrigger : MonoBehaviour
{
    public Transform player;
    public Transform EndOflevel;
    Vector3 defaultPoint;
    NavMeshAgent agent;
    Transform currentTarget;


    private void OnEnable()
    {
        //transform.position = EndOflevel.position;
    }

    void Start()
    {
        defaultPoint = transform.position;
        StartCoroutine(InitializeAgent());
    }

    IEnumerator InitializeAgent()
    {
        yield return new WaitForEndOfFrame();
        agent = GetComponent<NavMeshAgent>();
        currentTarget = player;

        // Sample a position on the NavMesh and move the agent to that position
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            agent.transform.position = hit.position;
        }
        else
        {
            Debug.LogError("Could not find a valid position on the NavMesh!");
        }
    }



    private void Update()
    {
        if (agent != null && agent.enabled)
        {
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                Debug.Log("Switching target...");
                SwitchTarget();
            }
            agent.SetDestination(currentTarget.position);
        }
    }

    void SwitchTarget()
    {
        Debug.Log("Current target before switch: " + currentTarget.name);
        currentTarget = currentTarget == player ? EndOflevel : player;
        Debug.Log("Current target after switch: " + currentTarget.name);
    }




}