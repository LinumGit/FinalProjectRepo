using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamage : MonoBehaviour
{

    public int arrowDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log(collision.name);
            if (collision.name.Contains("Boss"))
            {
                collision.GetComponent<BossHealth>().takeDamage(arrowDamage);
            } else {
                collision.GetComponent<EnemyHealth>().takeDamage(arrowDamage);
            }            
        }
    }
}
