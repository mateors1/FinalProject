using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskforHelp : MonoBehaviour
{
    [SerializeField] GameObject askforhelpbutton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            askforhelpbutton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        askforhelpbutton?.SetActive(false);
    }
}
