using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Define the variable here at the top in the class code so it will be accessable everywhere, private so it won't be accesed by other codes
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    

    //When we want to pass a layer we declare it as a layer mask (which we have to do to show that player is touching ground layer which is assinged to terrain)
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Animator anim;

    //With the enum, we are creating it's own variable type so we can pull it up by doing Movementstate.
    private enum MovementState { idle, running, jumping, falling }

    private float dirX = 0f;
    private float lastDirection = 0f;
   [SerializeField] private float moveSpeed = 7f;
   [SerializeField] private float jumpForce = 7f;

     
    // Start is called before the first frame update
    private void Start()
    {
        //execute what rb exquals here so it does on start
        rb = GetComponent<Rigidbody2D>();
       
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    private void Update()
    {           //We use get keydown so that it will only execute when it is pressed down
                //Better to use the command press button down so it can later be remppaed, when doing this, bottom (in this case jump) will be in caps

        //When doing left and right movement, we get a + or - x value, use input.get axis to get the axis of the orizational
        if(dirX != 0)
        {
            lastDirection = dirX;
            if(dirX < 0)
            {
                lastDirection = -1;
            }
            else
            {
                lastDirection = 1;
            }
        }
       dirX  = Input.GetAxis("Horizontal");
        //rb.vecolicty, calls the rigid body compoenet and then allows you to access velocity
        //Mulitply it by dirx so if it is negitive you go left, if positive you go right
        //Don't pass y value of zero, as it is in update, keep the rb.velocity.y which is the velocity of the value before 
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            
           

            //Use get component to get access to the compenent in unity
            //Vector3, data holder for 3 values (x, y, z)
            //Can often use vector2 for 2d game as there are only two directions to move
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);


        }
        //Now we can just call the code here
        UpdateAnimationState();

        anim.SetFloat("movedirection", dirX);
        anim.SetFloat("lastmovedirection", lastDirection);
    }
    //To make the code clearning, mae this code for updating animation state, do the () after the moethod meaning it doesn't return anything
    private void UpdateAnimationState()
    { //This valuble state will get assigned a value depending on our movement

     /*
        MovementState state;
        if (dirX > 0f)
        {

            state = MovementState.running;
            sprite.flipX = false;
        }
        
        else if (dirX < 0f)
        {
            state = MovementState.running;
            //Flip sprite here so that when it is facing left will flip to left 
            sprite.flipX = true;
        }
        
        else
        {
            state = MovementState.idle;
        }
         //We do the a seperate if as we don't want to see a running aninmation while in the air, state will be overwritten if we are jumping (instead of running)
         //We will use they y vaclocity to see if we are running, jumping or standing on the ground
         
        if (rb.velocity.y > .1f)//With this, we are checking the velocity of the rigid body, if greater than 0, we are jumping, use .1f as there is some inprecision in the vecloity value , use a small value 

        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        //second state is supposed to be a int but it is an enum, to get around this  put the (int)
        anim.SetInteger("state", (int) state);

        */
    }

    private bool IsGrounded()
    {
        //We create a box around our player that has the same shape as the box collider (green rectangle), size and bounds do this
        //, rotation is zero, vector2.down moves the box just slightly downwards, we can use this box to see if something overlapps with it, example the ground
        //We do reutrn so that whenever isgrounded is run, it will return if the cast is on jumpable ground
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

    }
}
















/*
//OLD METHOD USED FOR JUST RUNNING AND IDLE
private void UpdateAnimationState()
{
    if (dirX > 0f)
    {
        //Set this anim to change bool depending on if you are moving right or right
        anim.SetBool("running", true);
        sprite.flipX = false;
    }
    //You then do else if to see if DIRX is less than zero, set to running as this will mean running left
    else if (dirX < 0f)
    {
        anim.SetBool("running", true);
        //Flip sprite here so that when it is facing left will flip to left 
        sprite.flipX = true;
    }
    //Do the else here to check if the variable is 0, then should be flase and set to idle which is running = false
    else
    {
        anim.SetBool("running", false);
    }

*/