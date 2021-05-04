using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy enemy;
    public Animator anim;
    public Rigidbody2D rb;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        anim.SetBool("isDead", false);
    }

    private void Update()
    {
        if(enemy.healthPoints <= 0)
        {
            StartCoroutine(enemyFadeOut());
        }
    }

    public void takeDamage(float damage)
    {
        enemy.healthPoints -= damage;
        AudioManager.instance.playAudio(AudioManager.instance.hit);
        anim.SetTrigger("Hurt");

        if(enemy.healthPoints <= 0)
        {
            anim.SetBool("isDead", true);
            Die();
        }
    }

    public void Die()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.gravityScale = 0;
        enemy.GetComponent<EnemyMovement>().enabled = false;
        enemy.GetComponent<CircleCollider2D>().enabled = false;
        enemy.GetComponent<BoxCollider2D>().enabled = false;
        AudioManager.instance.playAudio(AudioManager.instance.skeletonDeath);
        //StartCoroutine(selfDestruct());
    }

    public void fadeOut()
    {
        Color objectColor = enemy.GetComponent<Renderer>().material.color;
        float fadeAmount = objectColor.a -= (1 * Time.deltaTime);
        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        enemy.GetComponent<Renderer>().material.color = objectColor;
        if(objectColor.a <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator enemyFadeOut()
    {
        yield return new WaitForSeconds(7f);
        fadeOut();
    }
}
