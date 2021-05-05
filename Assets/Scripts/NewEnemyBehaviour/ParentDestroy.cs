using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentDestroy : MonoBehaviour
{
    public Enemy enemyHealth;
    void Start()
    {
        enemyHealth = GetComponentInChildren<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        checkAlive();
    }

    public void checkAlive()
    {
        if(enemyHealth.healthPoints <= 0 && !enemyHealth.shouldRespawn)
        {
            StartCoroutine(waitDestroy());
        }
    }

    IEnumerator waitDestroy()
    {
        yield return new WaitForSeconds(9f);
        Destroy(gameObject);
    }
}
