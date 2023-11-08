using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

public class ClockSpawner : MonoBehaviour
{
    // Variables related to spawning and positioning
    public GameObject clockPlane; // Represents the clock plane game object
    public GameObject objectToSpawn; // Represents the object to be spawned
    public float distanceFromCenter; // Represents the distance from the center of the clock plane
    public SpawnDirection spawnDirection; // Represents the direction in which the object will spawn

    // Variables related to level management and control
    [SerializeField] bool advancesLevel; // Indicates whether the level advances
    [SerializeField] bool isLevelGoal; // Indicates if the current level is the goal
    [SerializeField] int currentLevel; // Represents the current level
    int nextRandomLevel; // Represents the next random level
    [SerializeField] bool canMovePreviousLevel; // Indicates if the previous level can be moved
    bool islvloneCollider = true; // Indicates if it's the first level collider
    [SerializeField] bool canUseCollider = true; // Indicates if the collider can be used
    SceneTriggerManager triggerManager; // Manages scene triggers
    [SerializeField] float timeWithTriggersDisabled = 5f; // Represents the time with triggers disabled

    // Called when the script is enabled
    private void OnEnable()
    {
        
        triggerManager = FindFirstObjectByType<SceneTriggerManager>(); // Find and assign the scene trigger manager
        triggerManager.SwitchDelegates += ReEnableTriggers; // Assign the function to re-enable triggers
    }

    // Enumeration representing different spawn directions
    public enum SpawnDirection
    {
        ThreeOClock = 0,
        SixOClock = 1,
        NineOClock = 2,
        TwelveOClock = 3
    }

    // Called when the collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player and if the collider can be used
        if (other.CompareTag("Player") && canUseCollider)
        {
            // Enable the trigger if it's the first level collider
            if (islvloneCollider)
            {
                FirstLevelColliderController.instance.EnableTrigger();
                islvloneCollider = false;
            }

            // Check for different conditions and perform appropriate actions
            if (advancesLevel && isLevelGoal)
            {
                AdvanceToNextLevel(); // Advance to the next level
            }
            else if (isLevelGoal)
            {
                LoadNextLevel(); // Load the next level
            }
            else if (GameManager.instance.unlockedLevels > 1)
            {
                LoadRandomLevel(); // Load a random level
            }
            triggerManager.BlockTriggers(); // Block triggers in the scene
        }
        else if (other.CompareTag("Player")&& !canUseCollider)
        {
            triggerManager.BlockTriggers();
        }
    }

    // Spawn the object at the specified clock position and direction
    void SpawnObjectAtClockPosition(SpawnDirection direction, GameObject nextLevel)
    {
        // Get the size of the clockPlane
        Vector3 clockPlaneSize = clockPlane.GetComponent<MeshRenderer>().bounds.size;

        // Calculate the distance from the center based on the size of the clockPlane
        distanceFromCenter = clockPlaneSize.x;

        // Determine the spawn direction based on the enum value
        Vector3 spawnDirectionVector;
        switch (direction)
        {
            // Assign the appropriate spawn direction based on the enum value
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
        LevelLoadBalancing(nextLevel); // Perform scene load balancing
        RebakeNavmesh(nextLevel); // Rebake the NavMesh for the scene
    }

    // Rebakes the NavMesh for the specified nextLevel
    void RebakeNavmesh(GameObject nextLevel)
    {
        NavMeshSurface surface = nextLevel.GetComponentInChildren<NavMeshSurface>();
        if (surface != null)
        {
            surface.BuildNavMesh(); // Build the NavMesh for the surface
            Debug.Log("navmesh baked");
        }
    }

    // Load a random level based on the unlocked levels in the game manager
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

    // Load the next level based on the current level index
    void LoadNextLevel()
    {
        int nextLevelIndex = currentLevel + 1;
        if (nextLevelIndex < GameManager.instance.gameLevels.Length)
        {
            SpawnObjectAtClockPosition(spawnDirection, GameManager.instance.gameLevels[nextLevelIndex]);
        }
    }

    // Advance to the next level and update the game manager variables accordingly
    void AdvanceToNextLevel()
    {
        LoadNextLevel();
        GameManager.instance.unlockedLevels++;
        GameManager.instance.ScenesSolved++;
        advancesLevel = false;
    }

    // Perform scene load balancing for the specified nextLevel
    void LevelLoadBalancing(GameObject nextLevel)
    {
        if (SceneBalancer.Instance != null)
        {
            SceneBalancer.Instance.LoadBalanceSCenes(nextLevel);
        }
    }

    // Coroutine to control the collider usage and re-enable it after a certain duration
    IEnumerator CanUseTriggerAgain()
    {
        canUseCollider = !canUseCollider;
        yield return null;
    }

    // Re-enable triggers after the specified duration
    void ReEnableTriggers()
    {
        StartCoroutine(CanUseTriggerAgain());
    }

    // Called when the script is disabled
    private void OnDisable()
    {
        triggerManager.SwitchDelegates -= ReEnableTriggers;
    }
}
