using System.Collections.Generic;
using UnityEngine;

public class MonkeysClimbing : MonoBehaviour
{
    private List<Transform> arboles = new List<Transform>();  // Lista de �rboles
    private Transform currentBaseArbol;  // El objeto base de �rbol actual
    public float climbSpeed = 1.0f; // Velocidad de subida
    private bool isClimbing = false;
    Animator animator;
    AnimalNavigation animNav;

    void Update()
    {
        if (isClimbing)
        {
            transform.Translate(Vector3.up * climbSpeed * Time.deltaTime);
        }
    }

    public void AddBaseArbol(Transform baseArbol)
    {
        arboles.Add(baseArbol);
    }

    // Este m�todo se llama cuando el personaje entra en el �rea del trigger del �rbol
    public void EnterArbolArea(Transform baseArbol)
    {
        currentBaseArbol = baseArbol;
        isClimbing = true;
        animNav.canFollow = false;
        animNav.isSelectingDestination = false;
        animNav.isGoingToTarget = false;
    }

}