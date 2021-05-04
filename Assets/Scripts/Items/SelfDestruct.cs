using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timeToDestroy;

    void Start()
    {
        StartCoroutine(selfDestroy());  
    }
   
    IEnumerator selfDestroy()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
