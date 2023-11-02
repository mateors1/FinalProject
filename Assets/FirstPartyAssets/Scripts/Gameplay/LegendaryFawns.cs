using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LegendaryFawns : MonoBehaviour
{
    NavMeshAgent agent;
    public bool canRun;
    Vector3 defaultposition;
    [SerializeField] Transform destination;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        defaultposition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (canRun) {
            agent.SetDestination(destination.position);
        }
        
    }

    private void OnDisable()
    {
        transform.position = defaultposition;
    }
}
