using System.Collections.Generic;
using UnityEngine;

public class MonkeysClimbing : MonoBehaviour
{
    private List<Transform> arboles = new List<Transform>();  // Lista de árboles
    private Transform currentBaseArbol;  // El objeto base de árbol actual
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

    // Este método se llama cuando el personaje entra en el área del trigger del árbol
    public void EnterArbolArea(Transform baseArbol)
    {
        currentBaseArbol = baseArbol;
        isClimbing = true;
        animNav.canFollow = false;
        animNav.isSelectingDestination = false;
        animNav.isGoingToTarget = false;
    }

}