using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TouchMovementController : MonoBehaviour
{
    public CharacterController2D controller;
    //esto es para conectar el componente animator al script
    public Animator animator;
    [SerializeField] AudioSource walkSound;


    [SerializeField] Rigidbody2D rigid;
    public float runSpeed = 40f;
    [SerializeField] int basecoinCount = 6;
    [SerializeField] int actualCoinCount;
    [SerializeField] DialogManager talk;
    [SerializeField] DialogManagerES talkES;
    [SerializeField] Pause pause;
    [SerializeField] AudioSource jump_char_Sound;



    private float horizontalMove = 0f;
    public bool talkingControl = false;
    private bool jump = false;
    public bool close = false;
    public bool open = false;
    public bool isTalking;
    public bool isTalkingES;
    public bool isPaused;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        isTalking = talk.talking;
        isTalkingES = talkES.talking;      
        isPaused = pause.paused;

        if ((isTalking) || (isPaused) || (isTalkingES))
        {
            runSpeed = 0f;
            jump = false;
        }
        else if ((!isTalking) || (!isPaused) || (!isTalkingES))
        {
            runSpeed = 40f;
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                jump = true;
                jump_char_Sound.Play();

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
            walkSound.Play();
            jump = false;
        }
    }
}