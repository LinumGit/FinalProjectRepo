using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public float damageGiven = 10;
    public Animator animator;
    public int maxHealth = 100;
    private int currentHealth;

    private GameObject target; 

    public Transform player;
   
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        animator.SetBool("IsDead", true);
        Debug.Log("Enemy Died!");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponentInParent<AIDestinationSetter>().enabled = false;
        GetComponent<EnemyGFX>().enabled = false;
        Destroy(gameObject, 10);  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
        }
    }
}
