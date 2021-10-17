using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    


    [SerializeField] private Animator annimator;
    [SerializeField] private Rigidbody2D rigidbody2;

    void Start()
    {
      
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

        rigidbody2.bodyType = RigidbodyType2D.Static;
        annimator.SetTrigger("death");
       
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}

