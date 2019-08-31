using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TouchMovementController : MonoBehaviour
{
    public CharacterController2D controller;
    //esto es para conectar el componente animator al script
    public Animator animator;


    [SerializeField] Rigidbody2D rigid;
    public float runSpeed = 40f;
    [SerializeField] int basecoinCount = 6;
    [SerializeField] int actualCoinCount;
    [SerializeField] DialogManager talk;
    [SerializeField] Pause pause;


    private float horizontalMove = 0f;
    public bool talkingControl = false;
    private bool jump = false;
    public bool close = false;
    public bool open = false;
    public bool isTalking;
    public bool isPaused;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //esto es para que detecte de forma positiva o negativa el movimiento
        animator.setfloat("Speed", Mathf.Abs(horizontalMove));

        isTalking = talk.talking;
        isPaused = pause.paused;

        if ((isTalking) || (isPaused))
        {
            runSpeed = 0f;
            jump = false;
        }
        else if ((!isTalking) || (!isPaused))
        {
            runSpeed = 40f;
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }

        horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal") * runSpeed;



    }

    void FixedUpdate()
    {
        if (talkingControl != true)
        {
            // Move our character       
            controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
            jump = false;
        }
    }
}