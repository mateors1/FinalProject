using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;

    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        animator.SetTrigger("pop");
    }
}
