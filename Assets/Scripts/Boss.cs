using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static int bossHealthPoints = 50;
    public float attackRange = 10f;
    float lastAttackTime =3;
    public Transform firePoint;
    public GameObject projectile;
    public Transform target;
    float attackDelay = 1f;
    public float webForce;
    private bool right = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance (transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            Vector3 targetDir = target.position - transform.position;
           // float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            //Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
            //transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 90 * Time.deltaTime);
            if (Time.time > lastAttackTime + attackDelay)
            {
                RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.right, attackRange);
                if (hit.transform == target)
                {
                 GameObject newWeb = Instantiate (projectile, transform.position, transform.rotation);
                 newWeb.GetComponent <Rigidbody2D>().AddRelativeForce (new Vector2(webForce, 0f));
                 lastAttackTime = Time.time;
                }
            }
        }
    }
     private void OnTriggerEnter2D(Collider2D collision)
     {
         if(collision.CompareTag("Bullet"))
         {
             Destroy(collision.gameObject);
           bossHealthPoints --;

           if(bossHealthPoints <= 0)
           {
               Destroy(gameObject);
           }
         }

          if(collision.CompareTag("chargeBullet"))
         {
             Destroy(collision.gameObject);
           bossHealthPoints = bossHealthPoints -5;

           if(bossHealthPoints <= 0)
           {
               Destroy(gameObject);
           }
         }
     }
}
