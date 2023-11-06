using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTriggerManager : MonoBehaviour
{
    public delegate void SceneBalanceTriggerController();
    public event SceneBalanceTriggerController SwitchDelegates;


    public void BlockTriggers()
    {
        SwitchDelegates?.Invoke();
    }

}
