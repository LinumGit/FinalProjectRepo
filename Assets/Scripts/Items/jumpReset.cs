using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpReset : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            PlayerJump.instance.airJumpCount = 0;
        }
    }
}
