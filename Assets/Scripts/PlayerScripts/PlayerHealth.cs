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
    public GameObject gameOver;
    public bool isDead = false;

    //Private variables
    Rigidbody2D rb;
    Blink material;
    SpriteRenderer sprite;

    public static PlayerHealth instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        gameOver.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        currentHealth = PlayerPrefs.GetFloat("playerHealth", maxHealth);
        if (!isDead)
        {
            gameOver.GetComponent<CanvasGroup>().alpha = 0.0f;
        }
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            isDead = true;
        }
        deadCheck();
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
                
                isDead = true;
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

    public void deadCheck()
    {
        if (isDead)
        {
            Time.timeScale = 0;

            gameOver.SetActive(true);
            AudioManager.instance.bgMusic.Stop();
            if (AudioManager.instance.bossBgMusic.isPlaying)
            {
                AudioManager.instance.bossBgMusic.Stop();
            }
            AudioManager.instance.playAudio(AudioManager.instance.playerDeath);

            if (gameOver.GetComponent<CanvasGroup>().alpha < 1f)
            {
                gameOver.GetComponent<CanvasGroup>().alpha += 0.005f;
            }
        }
    }

    public void healthSave()
    {
        DataManager.instance.playerHealthData(currentHealth);
    }

}
