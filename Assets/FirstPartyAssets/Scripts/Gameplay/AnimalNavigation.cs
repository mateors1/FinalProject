using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalNavigation : MonoBehaviour
{
    private bool canFollow = false;
    private bool isSelectingDestination = false;
    public Transform player;
    protected NavMeshAgent agentAnimal;
    Transform defaultpos;
    BoxCollider thisTrigger;
    public LayerMask groundLayer; // Assign the ground layer in the inspector

    void Start()
    {
        thisTrigger = GetComponent<BoxCollider>();
        defaultpos = transform;
        agentAnimal = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            HelpMeMeow();
        }
    }

    private void Update()
    {
        // Press 'K' to enter selection mode
        if (Input.GetKeyDown(KeyCode.E))
        {
            isSelectingDestination = true;
        }

        // If in selection mode and left mouse button is clicked, set the clicked position as the destination
        if (isSelectingDestination && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                agentAnimal.SetDestination(hit.point);
                canFollow = false;
                isSelectingDestination = false; // Exit selection mode
            }
        }

        if (!isSelectingDestination && agentAnimal.remainingDistance <= agentAnimal.stoppingDistance)
        {
            canFollow = true;
        }

        if (canFollow)
        {
            agentAnimal.SetDestination(player.position);
        }
    }

    private void OnDisable()
    {
        transform.position = defaultpos.position;
    }

    void HelpMeMeow()
    {
        canFollow = true;
        thisTrigger.enabled = false;
    }
}
