using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{

    [SerializeField] float jumpForce = 400f;                                      // Amount of force added when the players jump
    [Range(0, 100)][SerializeField] float movementSpeed = 20f;                    //Amount of speed when the player moves to the sides    
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;    // How much to smooth out the movement
    [SerializeField] LayerMask isGround;                                          // A mask determining what is ground to the character
    [SerializeField] Transform groundCheck;                                       // A position marking where to check if the player if grounded
    [SerializeField] private bool airControl;                                     // Whether or not a player can steer while jumping;

    private Rigidbody2D rigid2D;
    const float groundedRadius = 0.2f;                                           // Radios of the overlap circle to determine if grounded
    private bool grounded;                                                       // Whether or not the player is grounded
    private bool facingRight = true;                                             //For determining which way the player is currently facing
    private Vector3 myVelocity = Vector3.zero;
    Vector2 movement;

    public UnityEvent OnLandEvent;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();       
    }


    void FixedUpdate ()
    {
        bool wasGrounded = grounded;
        grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, isGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        
        //only control the player if grounded or airControl is turned on
        if (grounded || airControl)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, rigid2D.velocity.y);

            // And then smoothing it out and applying it to the character
            rigid2D.velocity = Vector3.SmoothDamp(rigid2D.velocity, targetVelocity, ref myVelocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !facingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && facingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (grounded && jump)
        {
            // Add a vertical force to the player.
            grounded = false;
            rigid2D.AddForce(new Vector2(0f, jumpForce));
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

