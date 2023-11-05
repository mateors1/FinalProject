using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalNavigation : MonoBehaviour
{
    private bool canFollow = false;
    private bool isSelectingDestination = false;
    private bool isGoingToTarget = false;
    public Transform player;
    protected NavMeshAgent agentAnimal;
    Transform defaultpos;
    BoxCollider thisTrigger;
    Animator animator;
    public LayerMask groundLayer; // Assign the ground layer in the inspector

    void Start()
    {
        thisTrigger = GetComponent<BoxCollider>();
        defaultpos = transform;
        agentAnimal = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CounterTrigger.Instance.ChangeAnimalSprite(gameObject.tag);
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {
        
            HelpMeMeow();
            animator.SetBool("IsWalking", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }

    private void Update()
    {
        if (thisTrigger.enabled == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isSelectingDestination = true;
            }

            // If in selection mode and left mouse button is clicked, set the clicked position as the destination
            if (isSelectingDestination && Input.GetMouseButtonDown(0))
            {
                GoToTarget();
            }

            if (isGoingToTarget && !isSelectingDestination && agentAnimal.remainingDistance <= agentAnimal.stoppingDistance)
            {
                canFollow = true;
                isGoingToTarget = false;
            }

            if (canFollow)
            {
                agentAnimal.SetDestination(player.position);
            }
        }
        // Press 'K' to enter selection mode

    }

    private void OnDisable()
    {
        transform.position = defaultpos.position;
    }

    void HelpMeMeow()
    {
        canFollow = true;
        thisTrigger.enabled = false;
        agentAnimal.SetDestination(player.position);
    }

    void GoToTarget()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            agentAnimal.SetDestination(hit.point);
            canFollow = false;
            isGoingToTarget = true;
            isSelectingDestination = false; // Exit selection mode
        }
    }
}
