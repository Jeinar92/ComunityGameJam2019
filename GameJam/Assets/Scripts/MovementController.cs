using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public CharacterController2D controller;    

    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float runSpeed = 40f;
    [SerializeField] int basecoinCount = 6;
    [SerializeField] int actualCoinCount;

    private float horizontalMove = 0f;
    public bool talkingControl = false;
    private bool jump = false;
    public bool close = false;
    public bool open = false;

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
        } else if (talkingControl == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                open = true;       
            }
        }
    }   

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "AlterEgo")
        {
            collider.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            talkingControl = true;
            rigid.constraints = RigidbodyConstraints2D.FreezePosition;

           
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (open == true)
        {
            collision.gameObject.tag = "AlterEgoSpoken";
        }
        if ((close == true) && (collision.gameObject.tag == "AlterEgoSpoken"))
        {
            Destroy(collision.gameObject);
            close = false;
        }
    }
    
    void DeclineButton()
    {
        close = true;
        rigid.constraints = RigidbodyConstraints2D.None;
        talkingControl = false;
        actualCoinCount = basecoinCount;
    }
    void AcceptButton()
    {
        close = true;
        rigid.constraints = RigidbodyConstraints2D.None;
        talkingControl = false;
        actualCoinCount = basecoinCount + 999;
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
