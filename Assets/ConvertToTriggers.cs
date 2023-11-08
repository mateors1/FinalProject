using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertToTriggers : MonoBehaviour
{
    private FirstLevelColliderController[] colliders;
    // Start is called before the first frame update
    void Start()
    {
        colliders = FindObjectsOfType<FirstLevelColliderController>();
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            foreach (FirstLevelColliderController trigger in colliders)
            {
                trigger.EnableTrigger();
            }
        }
    }
}
