using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTriggerManager : MonoBehaviour
{
    public delegate void SceneBalanceTriggerController();
    public event SceneBalanceTriggerController SwitchDelegates;
    public event SceneBalanceTriggerController EnableInLevelTriggers;


    public void BlockTriggers()
    {
        SwitchDelegates?.Invoke();
    }

    public void EnableTriggers()
    {
        EnableInLevelTriggers?.Invoke();
    }

}
