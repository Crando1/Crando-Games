using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb2d;
    public Vector2 castDirection;
    [SerializeField] private float castForce = 100f;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ApplyDynamicBody()
    {
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.AddForce(castDirection * castForce , ForceMode2D.Impulse);

    }


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Earth"))
            {
                anim.SetTrigger("isBroken");
               


            }
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    private void DestroyRock()
    {

        Destroy(gameObject);
    }
}
    







