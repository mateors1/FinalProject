using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelColliderController : MonoBehaviour
{
    
    BoxCollider firstlevelColliderl;
    // Start is called before the first frame update
    void Start()
    {
        firstlevelColliderl = GetComponent<BoxCollider>();
       
    
    }

    // Update is called once per frame
  public void EnableTrigger()
    {
        if (firstlevelColliderl != null && firstlevelColliderl.isTrigger == false)
        {
            firstlevelColliderl.isTrigger=true;
        }
    }
}
