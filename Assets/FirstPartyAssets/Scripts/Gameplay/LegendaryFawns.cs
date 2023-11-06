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
            agent.SetDestination(destination.position);
        }
        if (agent.remainingDistance < 0.2f) ;
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        transform.position = defaultposition;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && counterDeer == false)
        {
            CounterTrigger.Instance.ChangeAnimalSprite(gameObject.tag);
            counterDeer = true;
        }
    }
}
