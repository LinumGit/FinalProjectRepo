using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    public float healthToGive;
    private float playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.GetComponent<PlayerHealth>().currentHealth < collision.GetComponent<PlayerHealth>().maxHealth)
            {
                collision.GetComponent<PlayerHealth>().currentHealth += healthToGive;
                AudioManager.instance.playAudio(AudioManager.instance.potion);
                Destroy(gameObject);
            }
        }
    } 
}
