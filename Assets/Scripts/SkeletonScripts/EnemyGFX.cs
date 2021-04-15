﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); 
        }
    }

    private void FixedUpdate()
    {
        animator.SetFloat("speed", Mathf.Abs(aiPath.desiredVelocity.x));
    }
}
