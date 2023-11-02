using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimalIndication : MonoBehaviour
{
    private AnimalNavigation animalNavigation;
    public GameObject textBox;

    // Update is called once per frame
    void Update()
    {
        if (animalNavigation.inSpace == true)
        {
            StartIndication();
        }
    }

    private void StartIndication()
    {
        textBox.SetActive(true);
    }
}
