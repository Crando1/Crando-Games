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
    [SerializeField] private float moveSpeed = 7f;


    private bool jumpFire;
    private float lastMoveDirection = 0f;
    
    private float dirY;
    private float dirX;
    private bool isStandingOnEarth = false;
    private bool canMove = true;
  

   

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //Input for rock throw
        if (Input.GetKeyDown(KeyCode.F) && IsGrounded() && isStandingOnEarth)
        {
            animator.SetTrigger("isThrowingRock");
           
        }
       
        ///Last movement
        dirX = Input.GetAxisRaw("Horizontal");
        if (dirX != 0 && canMove == true)
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
       
        //Jump controls
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpFire = true;
         
        }
       
        animator.SetFloat("lastmoveX", lastMoveDirection);

    }

    private void FixedUpdate()
    {   //Make diry (jumpFIRE= press space down) =jump height
        if (jumpFire)
        {
            dirY = jumpHeight;
            jumpFire = false;
        }
        else
        {
            dirY = 0;
        }
        
        //Apply move speed and flip spirte
        rigidBody2d.AddForce(new Vector2(dirX, dirY) * moveSpeed, ForceMode2D.Impulse);
        if(lastMoveDirection == 1)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
       
        //Is running animator control
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
        if(canMove == true)
        {
            rigidBody2d.bodyType = RigidbodyType2D.Dynamic;
        }
        else if(canMove == false)
        {
            rigidBody2d.bodyType = RigidbodyType2D.Static;
        }


        
    }
    //Tells when touching grounded to limit jump
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

    }
    //If colliding with trap, reset level
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        else if(collision.gameObject.CompareTag("Earth"))
        {
            isStandingOnEarth = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Earth"))
        {
            isStandingOnEarth = false;
        }
    }
    //If touches trap, repawn level
    private void Die()
    {
        animator.SetTrigger("death");
        canMove = false;

    }
    //restart level
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    //Make gizmo for player
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + castingPoint, .25f);

    }
    //Instanciate rock object
    private void RockUp()
    {
        RockThrow projectileScript = Instantiate(rockProjectile, transform.position + castingPoint, Quaternion.identity).GetComponent<RockThrow>();
        projectileScript.castDirection = new Vector2(lastMoveDirection, 0);
    }
    private void ToggleRunOn()
    {
        canMove = true;
    }
    private void ToggleRunOff()
    {
        canMove = false;

    }
}









