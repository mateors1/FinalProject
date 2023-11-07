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
            // C�digo de di�logo 1
            KingMonkeyCollider.enabled = false;
        }
        else
        {
            // C�digo de di�logo 2
        }
    }
}

