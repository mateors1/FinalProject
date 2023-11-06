using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        AppleInventory inventory = collision.gameObject.GetComponent<AppleInventory>();

        if (inventory != null )
        {
            inventory.ApplePickUp();
            gameObject.SetActive(false);
        }
    }
}
