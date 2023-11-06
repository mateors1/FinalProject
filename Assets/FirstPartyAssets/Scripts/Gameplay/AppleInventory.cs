using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleInventory : MonoBehaviour
{
    public int numApples { get; private set;  }
    // Start is called before the first frame update
    public void ApplePickUp()
    {
        numApples++;

        Debug.Log(numApples);
    }
}
