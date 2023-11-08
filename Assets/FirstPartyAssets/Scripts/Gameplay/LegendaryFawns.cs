using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LegendaryFawns : MonoBehaviour
{
    NavMeshAgent agent;
    public bool canRun;
    bool isMoving;
    Vector3 defaultposition;
    [SerializeField] Transform destination;

    private bool counterDeer = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        defaultposition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (canRun) {
            StartMoving();
        }
        if (agent.remainingDistance < 0.2f && isMoving);
        {
           // gameObject.SetActive(false);
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && counterDeer == false)
        {
            CounterTrigger.Instance.ChangeAnimalSprite(gameObject.tag);
            counterDeer = true;
        }
    }
    
    void StartMoving()
    {
        agent.SetDestination(destination.position);
        isMoving = true;    
    }
}
