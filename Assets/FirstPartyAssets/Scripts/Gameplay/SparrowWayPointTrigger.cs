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
    private bool counterSparrow = false;

    private void OnEnable()
    {
        //transform.position = EndOflevel.position;
        currentTarget = player;

    }

    void Start()
    {
        defaultPoint = transform.position;
        StartCoroutine(InitializeAgent());
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && counterSparrow==false)
        {
            CounterTrigger.Instance.ChangeAnimalSprite(gameObject.tag);
            counterSparrow = true;
        }
    }

    IEnumerator InitializeAgent()
    {
        
        
        yield return new WaitForEndOfFrame();
        
        

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
        // Check if path has been calculated for the agent
        if(!agent.pathPending)
        {
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                Debug.Log("Switching target...");
                SwitchTarget();
            }
            // Ensure that the new destination is on the NavMesh
            NavMeshHit hit;
            if (NavMesh.SamplePosition(currentTarget.position, out hit, 1.0f, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
            else
            {
                Debug.LogError("Cannot set destination: Target position is not on the NavMesh.");
            }
        }
    }
}

    void SwitchTarget()
    {
        Debug.Log("Current target before switch: " + currentTarget.name);

        // Check if the player is on the NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(player.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            // If the player is on the NavMesh, switch between the player and the end of level
            currentTarget = currentTarget == player ? EndOflevel : player;
        }
        else
        {
            // If the player is not on the NavMesh, set the target to the end of level
            currentTarget = EndOflevel;
            Debug.Log("Player is not on the NavMesh. Setting target to EndOfLevel.");
        }
        Debug.Log("Current target after switch: " + currentTarget.name);
    }





}