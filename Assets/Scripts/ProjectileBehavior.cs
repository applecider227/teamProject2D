using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float Speed = 0;
    bool facingRight = true;


    // Update is called once per frame
   private void Update()
    {
        if (facingRight = true)
        {
        transform.position += transform.right * Time.deltaTime * Speed;
        }

        if (facingRight = !true)
        {
           transform.position += -transform.right * Time.deltaTime * Speed; 
        }
    }

  private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
          
            Destroy(collision.collider.gameObject);
        }
        
    }
}
