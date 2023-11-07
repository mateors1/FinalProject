using UnityEngine;

public class MonkeyTreeBehaviour : MonoBehaviour
{
    // Referencia al objeto base de árbol del árbol actual
    public Transform baseArbol;
    public GameObject apple;
    //public Transform appleInventory;

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

            Invoke("SpawnApple", 3f);

        }
    }


    private void SpawnApple()
    {
        Vector3 appleSpawnPosition = baseArbol.position + new Vector3(0, 15, 0);
        GameObject apples = Instantiate(apple, appleSpawnPosition, Quaternion.identity);
        //apples.transform.parent = appleInventory;
    }
}

