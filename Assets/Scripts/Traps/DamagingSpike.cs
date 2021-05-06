using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingSpike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth.instance.takeDamage(25);
        }
    }
}
