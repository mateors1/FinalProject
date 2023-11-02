using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threelegendaryFawnsController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LegendaryFawns[] legfendaryFawns;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MakeEmRoam());
        }
    }


    IEnumerator MakeEmRoam()
    {
        yield return new WaitForSeconds(5);
        foreach (LegendaryFawns legendaryFawn in legfendaryFawns)
        {
            legendaryFawn.canRun = true;
        }
    }
}
