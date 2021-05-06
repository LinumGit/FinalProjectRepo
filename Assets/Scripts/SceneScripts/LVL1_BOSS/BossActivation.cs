using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject bossGO;

    private void Start()
    {
        bossGO.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BossUI.instance.BossActivator();
            AudioManager.instance.bgMusic.Stop();
            StartCoroutine(waitForBoss());
        }
    }

    IEnumerator waitForBoss()
    {
        PlayerMovement.instance.speed = 0;
        AudioManager.instance.bossBgMusic.Play();
        bossGO.SetActive(true);
        yield return new WaitForSeconds(3f);
        PlayerMovement.instance.speed = 2f;
        Destroy(gameObject);
    }
}
