using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonkeysClimbing : MonoBehaviour
{
    private List<Transform> arboles = new List<Transform>();  // Lista de árboles
    public float climbSpeed = 1.0f; // Velocidad de subida
    private bool isClimbing = false;
    Animator animator;
    AnimalNavigation animNav;
    NavMeshAgent animNavMeshAg;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animNav = GetComponent<AnimalNavigation>();
        animNavMeshAg = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (isClimbing)
        {
            if (transform.position.y < 5)
            {
                transform.Translate(Vector3.up * climbSpeed * Time.deltaTime);
            }
            else
            {
                Destroy(gameObject);

                //parte de la manzana

            }
        }
    }

    public void AddBaseArbol(Transform baseArbol)
    {
        arboles.Add(baseArbol);
    }

    // Este método se llama cuando el personaje entra en el área del trigger del árbol
    public void EnterArbolArea()
    {
        animator.SetBool("IsJumping", true);
        animNav.canFollow = false;
        animNav.isSelectingDestination = false;
        animNav.isGoingToTarget = false;
        animNavMeshAg.enabled = false;
        isClimbing = true;
    }

}