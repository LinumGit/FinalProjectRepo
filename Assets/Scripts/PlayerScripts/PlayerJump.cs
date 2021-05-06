using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerJump : MonoBehaviour
{
    //force, apply force, 1x
    [Header("Jump Details")]
    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stopJump;
    public int airJumpCount;
    public int maxJumpCount;

    public static PlayerJump instance;

    [Header("Ground Details")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float radOCircle;
    public bool grounded;

    [Header("Components")]
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        airJumpCount = 1;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, radOCircle, whatIsGround);

        if (grounded)
        {
            airJumpCount = 0;
            jumpTimeCounter = jumpTime;
            animator.ResetTrigger("jump");
            animator.SetBool("Falling", false);
        }

        //press
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                stopJump = false;
                //Activa l'animació
                animator.SetTrigger("jump");
            }
            else
            {
                if (airJumpCount < maxJumpCount)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    stopJump = false;
                    //Activa l'animació
                    animator.ResetTrigger("jump");
                    animator.SetTrigger("jump");
                    airJumpCount++;
                }
            }

        } 

        //hold
        if (Input.GetButton("Jump") && !stopJump && jumpTimeCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
            animator.SetTrigger("jump");
        }

        //release
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stopJump = true;
            animator.SetBool("Falling", true);
            animator.ResetTrigger("jump");
        }

        if(rb.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, radOCircle);
    }
    private void FixedUpdate()
    {
        layerChange();
    }

    private void layerChange()
    {
        if (!grounded)
        {
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }
}
