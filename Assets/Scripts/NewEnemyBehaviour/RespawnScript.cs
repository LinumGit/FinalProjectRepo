using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public float respawnTime, respawnCd;
    public GameObject respawnableEnemy;
    public Animator anim;
    public float originalHealth;

    // Start is called before the first frame update
    void Start()
    {
        originalHealth = GetComponentInChildren<Enemy>().maxHealth;
        anim = GetComponentInChildren<EnemyHealth>().anim;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator respawnEnemy()
    {
        respawnableEnemy.GetComponent<EnemyMovement>().rb.constraints = RigidbodyConstraints2D.FreezeAll;
        respawnableEnemy.GetComponent<EnemyMovement>().enabled = false;
        yield return new WaitForSeconds(respawnTime);
        respawnableEnemy.GetComponent<Enemy>().healthPoints = originalHealth;
        anim.SetBool("respawn", true);
        anim.SetBool("isDead", false);
        respawnableEnemy.GetComponent<EnemyMovement>().enabled = true;
        respawnableEnemy.GetComponent<EnemyMovement>().rb.constraints = RigidbodyConstraints2D.None;
        respawnableEnemy.GetComponent<EnemyMovement>().rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
