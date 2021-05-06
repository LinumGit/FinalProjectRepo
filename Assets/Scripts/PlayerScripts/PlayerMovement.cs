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
    private float currentDashTime;
    float dashDirection;

    public static PlayerMovement instance;

    private bool facingRight = true;

    public float dashCd;
    public GameObject startPoint;
    public Transform transform;
    public float speed = 2.0f;
    public float horizontalMovement;

    public float dashForce;
    public float startDashTime;
    public bool isDashing;
    public bool hasDashed;
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && horizontalMovement != 0 && !hasDashed)
        {
            isDashing = true;
            currentDashTime = startDashTime;
            rb2D.velocity = Vector2.zero;
            dashDirection = horizontalMovement;
        }

        if (isDashing)
        {
            speed = 5;
            rb2D.velocity = transform.right * dashDirection * dashForce;
            currentDashTime -= Time.deltaTime;

            if (currentDashTime <= 0)
            {
                isDashing = false;
                speed = 2;
                hasDashed = true;
            }
        }

        if(hasDashed)
        {
            dashCd -= Time.deltaTime;
            if(dashCd <= 0)
            {
                dashCd = 5;
                hasDashed = false;
            }
        }
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
