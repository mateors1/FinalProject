using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threelegendaryFawnsController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LegendaryFawns[] legfendaryFawns;
    private Animator animator;
    private Animator animator2;
    private Animator animator3;

    private void Start()
    {
        animator = GameObject.Find("Rambo").GetComponent<Animator>();
        animator2 = GameObject.Find("Entero").GetComponent<Animator>();
        animator3 = GameObject.Find("SoyCool").GetComponent<Animator>();

    }

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
        animator.SetBool("IsWalking", true);
        animator2.SetBool("IsWalking", true);
        animator3.SetBool("IsWalking", true);
        foreach (LegendaryFawns legendaryFawn in legfendaryFawns)
        {
            legendaryFawn.canRun = true;
            
        }
        
    }
}
