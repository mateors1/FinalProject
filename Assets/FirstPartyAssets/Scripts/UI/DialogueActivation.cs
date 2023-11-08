using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueActivation : MonoBehaviour
{
    public List<GameObject> buttonsToActivate;
    public GameObject dialogueBox;
    AppleInventory inventory;
    private bool activeDialogueSparrow = false;
    private bool activeDialogueDeer = false;
    private bool activeDialogueCroc = false;
    private bool activeDialogueMonkey = false;

    private void Start()
    {
        inventory = GetComponent<AppleInventory>();
    }

    private void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            foreach (GameObject obj in buttonsToActivate)
            {
                obj.SetActive(false);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // check the different object tags and gives the corresponding dialogue

        //start
        if (collision.gameObject.CompareTag("StartPoint") && activeDialogueSparrow == false)
        {
            buttonsToActivate[0].SetActive(true);
            GameObject.FindGameObjectsWithTag("StartPoint").ToList().ForEach(obj => obj.SetActive(false));
            activeDialogueSparrow = true;
        }

        // deer
        if (collision.gameObject.CompareTag("Deer") && activeDialogueDeer == false)
        {
            buttonsToActivate[1].SetActive(true);
            GameObject.FindGameObjectsWithTag("Deer").ToList().ForEach(obj => obj.SetActive(false));
            activeDialogueDeer = true;

        }

        // crocs
        if (collision.gameObject.CompareTag("Croc") && activeDialogueCroc == false)
        {
            buttonsToActivate[2].SetActive(true);
            activeDialogueCroc = true;
        }

        //monkeys
        if (collision.gameObject.CompareTag("Monkey") && activeDialogueMonkey == false)
        {
            buttonsToActivate[3].SetActive(true);
            activeDialogueMonkey = true;
        }

        //King monkey
        if (collision.gameObject.CompareTag("KingMonkey"))
        {
            if (inventory.numApples < 5)
            {
                buttonsToActivate[4].SetActive(true);
            }
            else if (inventory.numApples == 5)
            {
                buttonsToActivate[5].SetActive(true);
            }

        }


    }


}