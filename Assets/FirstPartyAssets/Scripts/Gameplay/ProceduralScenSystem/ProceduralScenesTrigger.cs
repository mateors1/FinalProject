using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralScenesTrigger : MonoBehaviour
{

    SceneTriggerManager triggerManager;
    [SerializeField] GameObject ScenePlane;
    [SerializeField] int currentLevel;
   [SerializeField] ClockSpawner.SpawnDirection spawnDirection;
    [SerializeField] bool advancesLevel; // Indicates whether the level advances
    [SerializeField] bool isLevelGoal; // Indicates if the current level is the goal
    int nextRandomLevel; // Represents the next random level


    [SerializeField] bool canUseCollider =true;


    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player and if the collider can be used
        if (other.CompareTag("Player") && canUseCollider)
        {
            // Enable the trigger if it's the first level collider


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

        }
        else if (other.CompareTag("Player") && !canUseCollider)
        {
            triggerManager.EnableTriggers();
        }
    }

    private void OnEnable()
    {
        if (currentLevel > 1)
        {
            canUseCollider = false;
        }
        triggerManager = FindFirstObjectByType<SceneTriggerManager>(); // Find and assign the scene trigger manager

        triggerManager.EnableInLevelTriggers += EnableOnLevelTriggers;
    }

    void EnableOnLevelTriggers()
    {
        canUseCollider = true;
    }

    // Called when the script is disabled
    private void OnDisable()
    {

        triggerManager.EnableInLevelTriggers -= EnableOnLevelTriggers;
        canUseCollider = false;
    }


    // Load the next level based on the current level index
    void LoadNextLevel()
    {
        int nextLevelIndex = currentLevel + 1;
        if (nextLevelIndex < GameManager.instance.gameLevels.Length)
        {
           ClockSpawner.instance.SpawnObjectAtClockPosition(spawnDirection, ScenePlane, GameManager.instance.gameLevels[nextLevelIndex], currentLevel);
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

    void LoadRandomLevel()
    {
        if (GameManager.instance.unlockedLevels != 0)
        {

            do
            {
                nextRandomLevel = Random.Range(0, GameManager.instance.unlockedLevels);
            } while (nextRandomLevel == currentLevel);


        }

        if (nextRandomLevel != currentLevel)
        {
            if (GameManager.instance.gameLevels[nextRandomLevel] != null && GameManager.instance.gameLevels[nextRandomLevel].activeSelf)
            {
                GameManager.instance.gameLevels[nextRandomLevel].SetActive(false);
            }



            ClockSpawner.instance.SpawnObjectAtClockPosition(spawnDirection, ScenePlane, GameManager.instance.gameLevels[nextRandomLevel], currentLevel);
        }


    }
}
