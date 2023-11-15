using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class ClockSpawner : MonoBehaviour
{
    // Variables related to spawning and positioning
    public GameObject clockPlane; // Represents the clock plane game object
    public GameObject objectToSpawn; // Represents the object to be spawned
    public float distanceFromCenter; // Represents the distance from the center of the clock plane
    public SpawnDirection spawnDirection; // Represents the direction in which the object will spawn

    
    public static ClockSpawner instance;

    // Called when the script is enabled
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
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


    // Spawn the object at the specified clock position and direction
    public void SpawnObjectAtClockPosition(SpawnDirection direction, GameObject clockPlane, GameObject nextLevel,  int currentLevel)
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
        LevelLoadBalancing(nextLevel, currentLevel); // Perform scene load balancing
        RebakeNavmesh(nextLevel); // Rebake the NavMesh for the scene
    }

    // Rebakes the NavMesh for the specified nextLevel
    void RebakeNavmesh(GameObject nextLevel)
    {
        NavMeshSurface surface = nextLevel.GetComponentInChildren<NavMeshSurface>();
        if (surface != null)
        {
            surface.BuildNavMesh(); 
        }
    }




    // Perform scene load balancing for the specified nextLevel
    void LevelLoadBalancing(GameObject nextLevel, int currentLevel)
    {
        if (SceneBalancer.Instance != null)
        {
            SceneBalancer.Instance.LoadBalanceSCenes(nextLevel, currentLevel);
        }
    }

 

}
