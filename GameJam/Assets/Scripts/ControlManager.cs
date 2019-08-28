using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public CharacterController2D controller;

    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float runSpeed = 40f;
    [SerializeField] int basecoinCount = 6;
    [SerializeField] int actualCoinCount;
    [SerializeField] DialogManager talk;


    private float horizontalMove = 0f;
    public bool talkingControl = false;
    private bool jump = false;
    public bool close = false;
    public bool open = false;
    public bool isTalking;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isTalking = talk.talking;
        if (isTalking)
        {
            runSpeed = 0f;
        } else
        {
            runSpeed = 40f;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
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
