using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{


    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer spriteRend;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float moveSpeed = 7f;
    
    private bool jumpFire;
    private float lastMoveDirection = 0f;

    private float dirY;
    private float dirX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (dirX != 0)
        {
            lastMoveDirection = dirX;
            if (dirX < 0)
            {
                lastMoveDirection = -1;
            }
            else
            {
                lastMoveDirection = 1;
            }
        }
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
    }



}
