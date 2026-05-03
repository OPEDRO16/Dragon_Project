using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{

    public float moveSpeed = 2;
    private Vector3 dir;
    CharacterController controller;
    float horizontal, vertical;

    [SerializeField] float groundOffset;
    [SerializeField] LayerMask groundLayer;
    Vector3 spherePos;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;

    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
        Gravity(); 

        animator.SetFloat("BlendX", horizontal);
        animator.SetFloat("BlendY", vertical);
        Console.WriteLine(moveSpeed);
    }

    void UpdateAnimator()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("Andar", true);
        }
        else
        {
            animator.SetBool("Andar", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Correr", true);
        }
        else
        {
            animator.SetBool("Correr", false);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Agachar", true);
        }
        else
        {
            animator.SetBool("Agachar", false);
        }
    }   

    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundOffset, transform.position.z);
        if(Physics.CheckSphere(spherePos,controller.radius - 0.05f, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Gravity()
    {
        if (!IsGrounded())
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = -2;
        }
        controller.Move(velocity * Time.deltaTime);
    }

}
