using UnityEngine;

public class MonkeyTreeBehaviour : MonoBehaviour
{
    // Referencia al objeto base de árbol del árbol actual
    public Transform baseArbol;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monkey"))
        {
            Debug.Log("Choco mono");
            MonkeysClimbing monkey = other.GetComponent<MonkeysClimbing>(); 

            monkey.AddBaseArbol(baseArbol);
            monkey.EnterArbolArea(baseArbol);
            gameObject.SetActive(false);
        }
    }
}