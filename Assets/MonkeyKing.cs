using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyKing : MonoBehaviour
{
    public AppleInventory player; 
    public BoxCollider KingMonkeyCollider; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && player.numApples == 5)
        {
            // Código de diálogo 1
            KingMonkeyCollider.enabled = false;
        }
        else
        {
            // Código de diálogo 2
        }
    }
}

