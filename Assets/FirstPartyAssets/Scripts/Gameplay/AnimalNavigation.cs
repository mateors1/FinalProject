using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalNavigation : MonoBehaviour
{
    private bool canFollow = false;
    public Transform player;
    protected NavMeshAgent agentAnimal;
    void Start()
    {
        agentAnimal = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canFollow = true;
        }
    }
    private void Update()
    {
        if (canFollow)
        {
            agentAnimal.SetDestination(player.position);
        }
    }

}