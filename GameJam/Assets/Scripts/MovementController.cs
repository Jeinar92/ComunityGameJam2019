using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public CharacterController2D controller;
    public bool talkingControl;

    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float runSpeed = 40f;  
    private float horizontalMove = 0f;
    private bool jump = false;
    public bool close = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (talkingControl != true)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (Input.GetButtonDown("Jump"))
            {
            jump = true;
            }  
        } else if(talkingControl == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                close = true;
                talkingControl = false;
                rigid.constraints = RigidbodyConstraints2D.None;
            }
        }
    }   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AlterEgo"))
        {
            talkingControl = true;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX
            | RigidbodyConstraints2D.FreezePositionY;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("AlterEgo"))
        {
            talkingControl = false;
            runSpeed = 40f;           

        }
    }

    void FixedUpdate()
    {
    // Move our character
        if (talkingControl != true)
        {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        }
    }
}
