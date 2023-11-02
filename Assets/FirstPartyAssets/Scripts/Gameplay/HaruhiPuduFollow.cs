using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HaruhiPuduFollow : MonoBehaviour
{

    NavMeshAgent m_Agent;
    Transform deerTarget;
    Vector3 defaultPos;

    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
       m_Agent.SetDestination(deerTarget.position);
        defaultPos = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
          transform.position = defaultPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_Agent.SetDestination(defaultPos);
        }
    }
}
