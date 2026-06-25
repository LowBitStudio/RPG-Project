using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Pl_Controller : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;
    
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        //Updating the movement animation
        basicMovementAnim();
        //Debug.Log("this player is moving at: " + moveInput);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Setting up the speed
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private Vector2 lastmoveDir = Vector2.down;
    private void basicMovementAnim()
    {
        // Moving
        if(moveInput != Vector2.zero)
        {
            lastmoveDir = moveInput;
            if(MathF.Abs(moveInput.x) > MathF.Abs(moveInput.y))
            {
                anim.Play(moveInput.x > 0 ? "Walk Right" : "Walk Left");
            }
            else
            { 
                anim.Play(moveInput.y > 0 ? "Walk Up" : "Walk Down");
            }
        }
        //Idle
        else
        {
            if(Mathf.Abs(lastmoveDir.x) > MathF.Abs(lastmoveDir.y))
            {
                anim.Play(lastmoveDir.x > 0 ? "Idle Right" : "Idle Left");
            }
            else 
            {
                anim.Play(lastmoveDir.y > 0 ? "Idle Up" : "Idle");
            }
        }
    }
}
