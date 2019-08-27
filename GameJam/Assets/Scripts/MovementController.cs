using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public CharacterController2D controller;
    

    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float runSpeed = 40f;  

    private float horizontalMove = 0f;
    public bool talkingControl = false;
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
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX
            | RigidbodyConstraints2D.FreezePositionY;
            if (Input.GetButtonDown("Jump"))
            {
                close = true;
                rigid.constraints = RigidbodyConstraints2D.None;
                talkingControl = false;
            }
        }
    }   

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "AlterEgo")
        {
            collider.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            collider.gameObject.tag = "AlterEgoSpoken";
            talkingControl = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((close == true) && (collision.gameObject.tag == "AlterEgoSpoken"))
        {
            Destroy(collision.gameObject);
            close = false;
        }
    }

    void FixedUpdate()
    {
        if (talkingControl != true)
        {
            // Move our character       
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }
}
