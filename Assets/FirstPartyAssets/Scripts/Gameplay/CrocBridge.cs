using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class CrocBridge : MonoBehaviour
{
    [SerializeField] GameObject[] crocBridge;
    int crocPieces;
    BoxCollider invisibleWall;

    void Start()
    {

        invisibleWall = GetComponent<BoxCollider>();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Croc")){
            other.gameObject.SetActive(false);
            if (crocPieces < crocBridge.Length)
            {
                AddaCroc();
            }
          
        }
    }

    void AddaCroc()
    {
        crocBridge[crocPieces].SetActive(true);
        crocPieces++;
        if (crocPieces >= crocBridge.Length)
        {
            invisibleWall.enabled = false;
        }
    }

}
