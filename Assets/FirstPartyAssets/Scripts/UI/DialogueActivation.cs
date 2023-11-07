using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueActivation : MonoBehaviour
{
    public List<GameObject> buttonsToActivate;
    public GameObject dialogueBox;
    AppleInventory inventory;

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
        if (collision.gameObject.CompareTag("StartPoint"))
        {
            buttonsToActivate[0].SetActive(true);
            GameObject.FindGameObjectsWithTag("StartPoint").ToList().ForEach(obj => obj.SetActive(false));
        }

        // deer
        if (collision.gameObject.CompareTag("Deer"))
        {
            buttonsToActivate[1].SetActive(true);
            GameObject.FindGameObjectsWithTag("Deer").ToList().ForEach(obj => obj.SetActive(false));

        }

        // crocs
        if (collision.gameObject.CompareTag("Croc"))
        {
            buttonsToActivate[2].SetActive(true);
        }

        //monkeys
        if (collision.gameObject.CompareTag("Monkey"))
        {
            buttonsToActivate[3].SetActive(true);
        }

        //King monkey
        if (collision.gameObject.CompareTag("KingMonkey"))
        {
            if (inventory.numApples < 5)
            {
                buttonsToActivate[4].SetActive(true);
            }else if(inventory.numApples == 5)
            {
                buttonsToActivate[5].SetActive(true);
            }
            
        }


    }


}
