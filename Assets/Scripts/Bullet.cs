using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    float inputHorizontal;

    public float TimeToLive = 1f;
    public int bulletDamage;


    void Start()
    {  
    
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);
        
    }

    void Update()
    {
        
 
    }
    void LateUpdate()
    {
     
    }

 private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
          
            Destroy(collision.collider.gameObject);
        }
        
    }
    public void StartShoot(bool isFacingLeft)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        if (isFacingLeft)
        {
           rb2d.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(speed, 0); 

        }

        Destroy(gameObject, TimeToLive);
    }
}
