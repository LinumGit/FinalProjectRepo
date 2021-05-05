using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    //Necessary for animations and physics
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    public static PlayerMovement instance;

    private bool facingRight = true;

    public GameObject startPoint;
    public Transform transform;
    public float speed = 2.0f;
    public float horizontalMovement;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Debug.Log(transform.position);
        transform.position = new Vector2(PlayerPrefs.GetFloat("playerX", startPoint.transform.position.x),PlayerPrefs.GetFloat("playerY", startPoint.transform.position.y));
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

    //Input de les físiques
    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
    }

    //Aplica les físiques
    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(horizontalMovement * speed * 1.5f, rb2D.velocity.y);
        Flip(horizontalMovement);
        myAnimator.SetFloat("floatSpeed", Mathf.Abs(horizontalMovement));
    }

    private void Flip(float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public void savePosition()
    {
        DataManager.instance.savePositionX(transform.position.x);
        DataManager.instance.savePositionY(transform.position.y);
    }

}
