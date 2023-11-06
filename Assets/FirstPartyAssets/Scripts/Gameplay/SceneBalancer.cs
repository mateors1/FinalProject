using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBalancer : MonoBehaviour
{
    public List<GameObject> levels;
    public static SceneBalancer Instance;
    [SerializeField] int scenesonlist;
    [SerializeField] GameObject firstOnlist;

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

    public void LoadBalanceSCenes(GameObject level)
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
}
