using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossUI : MonoBehaviour
{

    public GameObject bossPanel;
    public GameObject walls;

    public static BossUI instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        bossPanel.SetActive(false);
        walls.SetActive(false);
    }

    public void BossActivator()
    {
        bossPanel.SetActive(true);
        walls.SetActive(true);
    }

    public void bossDeactivator()
    {
        bossPanel.SetActive(false);
        walls.SetActive(false);
        StartCoroutine(bossDefeated());
    }

    IEnumerator bossDefeated() {
        var velocity = PlayerMovement.instance.GetComponent<Rigidbody2D>().velocity;
        velocity = new Vector2(0, velocity.y);
        PlayerMovement.instance.enabled = false;
        yield return new WaitForSeconds(4);
        PlayerMovement.instance.enabled = true;
        velocity = new Vector2(2, velocity.y);
    }
}
