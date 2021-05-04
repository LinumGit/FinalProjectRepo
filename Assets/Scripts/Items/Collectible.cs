using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int arrowsToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.playAudio(AudioManager.instance.arrowGet);
            SubItems.instance.subItem(arrowsToGive);
            Destroy(gameObject);
        }
    }
}
