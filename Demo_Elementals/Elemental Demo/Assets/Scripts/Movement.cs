using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    


    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Rigidbody2D rigidBody2d;
    [SerializeField] private float jumpHeight;
    [SerializeField] public Vector3 castingPoint;
    [SerializeField] private GameObject rockProjectile;

    private bool jumpFire;
    private float lastMoveDirection = 0f;
    
    
    private float dirY;
    private float dirX;

    [SerializeField] private float moveSpeed = 7f;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("isThrowingRock");
           
        }
       

        dirX = Input.GetAxisRaw("Horizontal");
        if (dirX != 0)
        {
            lastMoveDirection = dirX;
            if (dirX < 0)
            {
                lastMoveDirection = -1;
                castingPoint = new Vector3(Mathf.Abs(castingPoint.x) * -1, castingPoint.y, castingPoint.z);
            }
            else
            {
                lastMoveDirection = 1;
                castingPoint = new Vector3(Mathf.Abs(castingPoint.x) * 1, castingPoint.y, castingPoint.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpFire = true;
         
        }
       
        animator.SetFloat("lastmoveX", lastMoveDirection);

    }

    private void FixedUpdate()
    {
        if (jumpFire)
        {
            dirY = jumpHeight;
            jumpFire = false;
        }
        else
        {
            dirY = 0;
        }
        

        rigidBody2d.AddForce(new Vector2(dirX, dirY) * moveSpeed, ForceMode2D.Impulse);
        Debug.Log("Fixed Update: " + dirY);
        if(lastMoveDirection == 1)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        /*
        if (rigidBody2d.velocity.x > .01)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        */



        //animator.SetFloat("movedirX", Mathf.Round(rigidBody2d.velocity.x * 100f)/100f);
        //animator.SetFloat("movedirY", Mathf.Round(rigidBody2d.velocity.y * 100f) / 100f);

        if ((Mathf.Round(rigidBody2d.velocity.x * 100f) / 100f) != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if ((Mathf.Round(rigidBody2d.velocity.y * 100f) / 100f) > 0)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
        }
        else if ((Mathf.Round(rigidBody2d.velocity.y * 100f) / 100f) < 0)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);


        }
        else
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", false);
        }
    }

    private bool IsGrounded()
    {
        //We create a box around our player that has the same shape as the box collider (green rectangle), size and bounds do this
        //, rotation is zero, vector2.down moves the box just slightly downwards, we can use this box to see if something overlapps with it, example the ground
        //We do reutrn so that whenever isgrounded is run, it will return if the cast is on jumpable ground
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {


            Die();
        }
    }
    private void Die()
    {

        rigidBody2d.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");

    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + castingPoint, .25f);

    }

    private void RockUp()
    {
        RockThrow projectileScript = Instantiate(rockProjectile, transform.position + castingPoint, Quaternion.identity).GetComponent<RockThrow>();
        projectileScript.castDirection = new Vector2(lastMoveDirection, 0);
    }
}









