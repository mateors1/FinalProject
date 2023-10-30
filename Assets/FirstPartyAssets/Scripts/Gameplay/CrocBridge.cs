using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class CrocBridge : MonoBehaviour
{
    NavMeshLink crocBridge;    // Start is called before the first frame update
    void Start()
    {
        crocBridge = GetComponent<NavMeshLink>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
