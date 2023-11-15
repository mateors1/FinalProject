using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBalancer : MonoBehaviour
{
    public List<GameObject> levels;
    public static SceneBalancer Instance;
    [SerializeField] int scenesonlist;
    [SerializeField] GameObject firstOnlist;
    int currentLevel;

    private void Start()
    {
        Instance = this;
        levels.Add(GameManager.instance.gameLevels[0]);
        scenesonlist = levels.Count;
    }


    private void Update()
    {
        firstOnlist = levels[0];
    }

    public void LoadBalanceSCenes(GameObject level, int imOnLevel)
    {

        GameObject myCurrentLevel = GameManager.instance.gameLevels[imOnLevel];
        if (!levels.Contains(myCurrentLevel)) 
        {
            if (!levels.Contains(level))
            {
                levels.Add(level);
            }

            if (levels.Count >= 3)
            {

                levels[0].SetActive(false);
                levels.RemoveAt(0);
            }
        }

        else
        {
            if (!levels.Contains(level))
            {
                levels.Add(level);
            }
            if (levels.Count >= 3)
            {
                if (levels[0] == myCurrentLevel)
                {
                    levels[1].SetActive(false);
                    levels.RemoveAt (1);
                }
                else if (levels[1] == myCurrentLevel)
                {
                    levels[0] .SetActive(false);
                    levels.RemoveAt(0);
                }

            }
        }

        
    }
}
