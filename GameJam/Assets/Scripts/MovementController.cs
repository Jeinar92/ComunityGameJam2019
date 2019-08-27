using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public CharacterController2D controller;
    public LoadDialogs load;
    public bool talkingControl;

    [SerializeField] float runSpeed = 40f;
    

    private float horizontalMove = 0f;
    private bool jump = false;

    void Update()
    {
        talkingControl = load.talking;
        if (talkingControl == false)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

                    if (Input.GetButtonDown("Jump"))
                    {
                        jump = true;
                    }
        }
        
    }



    void FixedUpdate()

    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }

}
