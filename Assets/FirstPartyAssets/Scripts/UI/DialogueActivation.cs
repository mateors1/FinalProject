using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueActivation : MonoBehaviour
{
    public GameObject buttonToActivate;
    public GameObject dialogueBox;

    private void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            buttonToActivate.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión ocurrió con el objeto deseado
        if (collision.gameObject.CompareTag("StartPoint"))
        {
            Time.timeScale = 0.0f;
            buttonToActivate.SetActive(true);
            GameObject.FindGameObjectsWithTag("StartPoint").ToList().ForEach(obj => obj.SetActive(false));
        }
    }


}
