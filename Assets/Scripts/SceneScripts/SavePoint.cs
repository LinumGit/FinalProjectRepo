using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePoint : MonoBehaviour
{
    public GameObject saved;
    public Transform savePoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(gameSaved());
            XpScript.instance.saveXp();
            PlayerHealth.instance.healthSave();
            PlayerMovement.instance.savePosition();
            print("GameSaved!");
        }
    }

    IEnumerator gameSaved()
    {
        saved.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = false;
        PlayerMovement.instance.speed = 0;
        AudioManager.instance.gameSaved.Play(); 
        yield return new WaitForSeconds(3f);
        PlayerMovement.instance.speed = 2f;
        saved.SetActive(false);
    }
}
