using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    


    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Rigidbody2D rigidBody2d;
    


    private float jump;
    
    [SerializeField] private float dirY;
    [SerializeField] private float dirX;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");











    }

    private void FixedUpdate()
    {
        rigidBody2d.AddForce(new Vector2(dirX, dirY) * moveSpeed, ForceMode2D.Impulse);
        if(rigidBody2d.velocity.x > .01)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }






}




