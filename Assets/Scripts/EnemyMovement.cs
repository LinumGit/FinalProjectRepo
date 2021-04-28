using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed;
    Rigidbody2D rb;
    Animator anim;
    public Transform wallCheck, pitCheck, groundCheck;
    private bool wallDetected, pitDetected, isGrounded;
    public float detectionRadius;
    public LayerMask whatIsGround;

    public bool isStatic;
    public bool isWalker;
    private bool walksRight;
    public bool isPatrol;
    public bool shouldWait;
    public bool isWaiting;

    public float timeWaiting;

    public Transform pointA, pointB;
    bool goToA, goToB;

    void Start()
    {
        goToA = true;
        speed = GetComponent<Enemy>().speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectionRadius, whatIsGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectionRadius, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, detectionRadius, whatIsGround);

        if ( (pitDetected || wallDetected) && isGrounded)
        {
            flip();
        }
    }

    private void FixedUpdate()
    {
        if (isStatic)
        {
            anim.SetBool("Idle", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (isWalker)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Idle", false);
            if (!walksRight)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            } else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }
        if (isPatrol)
        {
            if (goToA)
            {
                if (!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                }
                
                if(Vector2.Distance(transform.position, pointA.position) < 0.2f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }

                    flip();
                    goToA = false;
                    goToB = true;
                }
            }
            if (goToB)
            {
                if (!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                }
               

                if (Vector2.Distance(transform.position, pointB.position) < 0.2f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }

                    flip();
                    goToA = true;
                    goToB = false;
                }
            }
        }
    }

    IEnumerator Waiting()
    {
        anim.SetBool("Idle", true);
        isWaiting = true;
        rb.velocity = new Vector2(0, rb.velocity.y);
        flip();
        yield return new WaitForSeconds(timeWaiting);
        isWaiting = false;
        anim.SetBool("Idle", false);
        flip();
    }

    public void flip()
    {
        walksRight = !walksRight;

        transform.localScale *= new Vector2(-1, transform.localScale.y);
    }
}
