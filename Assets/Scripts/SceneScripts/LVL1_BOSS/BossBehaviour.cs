using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour
{
    public Transform[] positions;
    public GameObject bossAttack;

    public float timeToShoot, cooldown;
    public float timeToTp, tpCooldown;

    public float bossHealth, currentHealth;
    public Image healthImg;
    public GameObject deathEffect;

    private void Start()
    {
        transform.position = positions[1].position;
        cooldown = timeToShoot;
        tpCooldown = timeToTp;
    }

    private void Update()
    {
        fightStructure();
        damageBoss();
        bossScale();
    }
        
    public void fightStructure()
    {
        cooldown -= Time.deltaTime;
        tpCooldown -= Time.deltaTime;

        if (cooldown <= 0f)
        {
            shootPlayer();
            cooldown = timeToShoot;
        }

        if (tpCooldown <= 0)
        {
            tpCooldown = timeToTp;
            Teleport();
        }
    }

    public void shootPlayer()
    {
        GameObject spell = Instantiate(bossAttack, transform.position, Quaternion.identity);
    }

    public void Teleport()
    {
        var initialPosition = Random.Range(0, positions.Length);
        transform.position = positions[initialPosition].position;
    }
   
    public void damageBoss()
    {
        currentHealth = GetComponent<Enemy>().healthPoints;
        AudioManager.instance.playAudio(AudioManager.instance.bossHit);
        healthImg.fillAmount = currentHealth / bossHealth;

        if(currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void bossScale()
    {
        if(transform.position.x > PlayerMovement.instance.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnDestroy()
    {
        BossUI.instance.bossDeactivator();
    }
}
