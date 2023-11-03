using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class AnimalIndication : MonoBehaviour
{

    public GameObject textBox;

    private bool isPlayerRange;
    SphereCollider thisTrigger;
    void Start()
    {
        thisTrigger = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (isPlayerRange && Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(textBox);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerRange = true;
            textBox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerRange = false;
            textBox.SetActive(false);
        }
    }

}
