using UnityEngine;

public class MonkeyTreeBehaviour : MonoBehaviour
{
    // Referencia al objeto base de árbol del árbol actual
    public Transform baseArbol;
    public GameObject apple;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monkey"))
        {
            Debug.Log("Choco mono");
            Debug.Log(other.gameObject.name);
            MonkeysClimbing monkey = other.gameObject.GetComponent<MonkeysClimbing>(); 

            monkey.AddBaseArbol(baseArbol);
            monkey.EnterArbolArea();
            gameObject.SetActive(false);

            SpawnApple(apple);

        }
    }


    private void SpawnApple(GameObject applePrefab)
    {
        Vector3 appleSpawnPosition = baseArbol.position + new Vector3(0, 15, 0);
        Instantiate(applePrefab, appleSpawnPosition, Quaternion.identity);

    }
}

