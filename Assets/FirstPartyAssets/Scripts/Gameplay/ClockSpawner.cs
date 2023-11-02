using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

public class ClockSpawner : MonoBehaviour
{

    public GameObject clockPlane;
    public GameObject objectToSpawn;
    public float distanceFromCenter;
    public SpawnDirection spawnDirection;
    [SerializeField] bool advancesLevel;
    [SerializeField]bool isLevelGoal;
    [SerializeField] int currentLevel;
    int nextRandomLevel;
    [SerializeField] bool canMovePreviousLevel;


    public enum SpawnDirection
    {
        ThreeOClock = 0,
        SixOClock = 1,
        NineOClock = 2,
        TwelveOClock = 3
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (advancesLevel && isLevelGoal)
            {
                AdvanceToNextLevel();
            }

            else if (isLevelGoal)
            {
                LoadNextLevel();
            }

            else if (GameManager.instance.unlockedLevels<1)
            {
                LoadRandomLevel();
            }
        }

        
    }

    
    

    void SpawnObjectAtClockPosition(SpawnDirection direction, GameObject nextLevel )
    {
        // Get the size of the clockPlane
        Vector3 clockPlaneSize = clockPlane.GetComponent<MeshRenderer>().bounds.size;

        

        // Calculate the distance from the center based on the size of the clockPlane
        distanceFromCenter = clockPlaneSize.x;

        // Determine the spawn direction based on the enum value
        Vector3 spawnDirectionVector;
        switch (direction)
        {
            case SpawnDirection.ThreeOClock:
                spawnDirectionVector = clockPlane.transform.right;
                break;
            case SpawnDirection.SixOClock:
                spawnDirectionVector = -clockPlane.transform.forward;
                break;
            case SpawnDirection.NineOClock:
                spawnDirectionVector = -clockPlane.transform.right;
                break;
            case SpawnDirection.TwelveOClock:
                spawnDirectionVector = clockPlane.transform.forward;
                break;
            default:
                spawnDirectionVector = clockPlane.transform.right;
                break;
        }

        // Calculate the world position of the spawned object
        Vector3 worldPosition = clockPlane.transform.position + spawnDirectionVector * distanceFromCenter;

        // Set the position of the spawned object
        nextLevel.transform.position = worldPosition;

        // Align the forward direction of plane 2 to face the opposite direction of the spawn direction
        nextLevel.transform.rotation = Quaternion.LookRotation(spawnDirectionVector, clockPlane.transform.up);
        nextLevel.SetActive(true);
        RebakeNavmesh(nextLevel); 
    }

    void RebakeNavmesh(GameObject nextLevel)
    {
        NavMeshSurface surface = nextLevel.GetComponentInChildren<NavMeshSurface>();
        if (surface != null)
        {
            surface.BuildNavMesh();
        }
    }

    void LoadRandomLevel()
    {
        
        if (GameManager.instance.unlockedLevels != 0)
        {
            do
            {
                nextRandomLevel = Random.Range(0, GameManager.instance.unlockedLevels);
            } while (nextRandomLevel == currentLevel);
        }

        if (nextRandomLevel < GameManager.instance.gameLevels.Length)
        {
            SpawnObjectAtClockPosition(spawnDirection, GameManager.instance.gameLevels[nextRandomLevel]);
        }
    }


    void LoadNextLevel()
    {
        int nextLevelIndex = currentLevel + 1;
        if (nextLevelIndex < GameManager.instance.gameLevels.Length)
        {
            SpawnObjectAtClockPosition(spawnDirection, GameManager.instance.gameLevels[nextLevelIndex]);
           // currentLevel = nextLevelIndex; // update currentLevel for this instance
        }
    }

    void AdvanceToNextLevel()
    {
        LoadNextLevel();
        GameManager.instance.unlockedLevels++;
        GameManager.instance.ScenesSolved++;
        advancesLevel = false;

    }

 
}
