using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BossUI.instance.BossActivator();
            StartCoroutine(waitForBoss());
        }
    }

    IEnumerator waitForBoss()
    {
        PlayerMovement.instance.speed = 0;
        yield return new WaitForSeconds(3f);
        PlayerMovement.instance.speed = 2f;
        Destroy(gameObject);
    }
}
