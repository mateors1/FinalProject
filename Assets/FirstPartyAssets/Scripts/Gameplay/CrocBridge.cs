using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class CrocBridge : MonoBehaviour
{
    NavMeshLink crocBridge;
    [SerializeField] int requiredCrocs;
    [SerializeField] int currentCrocs;
    [SerializeField] GameObject[] crocs;
    int crocIndex;
    // Start is called before the first frame update
    void Start()
    {
        crocBridge = GetComponent<NavMeshLink>();


    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Croc"))
        {
            other.gameObject.SetActive(false);
            AddCroc();
        }
            
           

        
    }

    private void AddCroc()
    {
        crocs[crocIndex].SetActive(true);
        crocIndex++;
        if (crocIndex >= crocs.Length - 1)
        {
            crocIndex = crocs.Length - 1;
        }
        currentCrocs++;
        if (currentCrocs == requiredCrocs)
        {
            crocBridge.enabled = true;
        }

    }
    



}
