using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //public variables
    public int maxHealth = 100;
    public float currentHealth;
    bool isInmune;
    public float inmunityTime;
    public Image healthImg;
    public float knockbackForce;

    //Private variables
    Rigidbody2D rb;
    Blink material;
    SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthImg.fillAmount = currentHealth / 100;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInmune)
        {
            
            currentHealth -= collision.GetComponent<Enemy>().damageGiven;
            if (currentHealth > 0)
            {
                AudioManager.instance.playAudio(AudioManager.instance.playerHit);
            }
            
            StartCoroutine(Inmunity());

            if (collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(-knockbackForce, 100), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(knockbackForce, 100), ForceMode2D.Force);

            }

            if (currentHealth <= 0)
            {
                AudioManager.instance.playAudio(AudioManager.instance.playerDeath);
                print("Player mort");
            }
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
    }

    IEnumerator Inmunity()
    {
        isInmune = true;
        
        yield return new WaitForSeconds(inmunityTime);
        
        isInmune = false;
    }

}
