using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public AudioClip pickupSound;
    private AudioSource audioSource; 

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        AppleInventory inventory = collision.gameObject.GetComponent<AppleInventory>();

        if (inventory != null)
        {
            audioSource.PlayOneShot(pickupSound);
            StartCoroutine(PlayTheChime());
            gameObject.SetActive(false);

            
        }

        IEnumerator PlayTheChime()
        {
            inventory.ApplePickUp();
            yield return null;
        }
    }
}
