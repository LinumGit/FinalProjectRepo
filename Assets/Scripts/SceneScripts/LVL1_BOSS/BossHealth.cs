using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    Enemy enemy;
    public Rigidbody2D rb;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (enemy.healthPoints <= 0)
        {
            StartCoroutine(enemyFadeOut());
        }
    }

    public void takeDamage(float damage)
    {
        enemy.healthPoints -= damage;

        if (enemy.healthPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void fadeOut()
    {
        Color objectColor = enemy.GetComponent<Renderer>().material.color;
        float fadeAmount = objectColor.a -= (1 * Time.deltaTime);
        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        enemy.GetComponent<Renderer>().material.color = objectColor;
        if (objectColor.a <= 0)
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
