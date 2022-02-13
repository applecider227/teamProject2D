using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttack : MonoBehaviour
{
    public KeyCode chargeAttack;
    public float chargeTimer = 0;
    public GameObject chargeBullet;

    public Transform firePoint;

    float inputHorizontal;
    public Rigidbody2D rb;
    public float speed = 20f;
    bool isFacingLeft;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        
        if (Input.GetKey (chargeAttack))
        {
            chargeTimer+=Time.deltaTime;
        }

        if ((Input.GetKeyUp (chargeAttack)) && (chargeTimer > 1))
        {
               GameObject b = Instantiate(chargeBullet);
           b.GetComponent<Bullet>().StartShoot(isFacingLeft);
           b.transform.position = firePoint.transform.position;
               chargeTimer=0;
        }

        if ((Input.GetKeyUp (chargeAttack)) && (chargeTimer < 1))
        {
            chargeTimer=0;
        }
    }
    private void FixedUpdate()
    {
         if (inputHorizontal > 0)
        {
            firePoint.transform.localScale = new Vector3(1,1,1);
            isFacingLeft = false;
            
           
        }
        if (inputHorizontal < 0)
        {
            firePoint.transform.localScale = new Vector3(-1,1,1);
            isFacingLeft = true;
        }
    }
}
