using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
  

    // Start is called before the first frame update
   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * 7f, rb.velocity.y);


        if (Input.GetButtonDown("Jump"))
        {
           rb.velocity = new Vector2(rb.velocity.x, 14f);
        }

        if(dirx != 0f)
        {

        }
        
        if (dirx > 0f)
        {
            anim.SetBool("Running", true);
        }
        else if (dirx < 0f)
        {
            anim.SetBool("Running", true);

        }
        else
        {
            anim.SetBool("Running", false);
        }


    }  
    private void UpdateAninmationUpdate()
    {

    }


}
