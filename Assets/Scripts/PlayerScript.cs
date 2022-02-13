using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float velocity = 5;
    private Rigidbody2D rb;
    bool isGrounded;
    public Transform groundCheck;
    public Transform leftWallCheck;
    public Transform rightWallCheck;
    public LayerMask groundlayer;

    public float runSpeed = 40f;

    private int healthPoints = 3;
    float inputHorizontal;
    public GameObject firePoint;
    public GameObject ProjectilePrefab;
    public Transform LaunchOffset;
    Vector2 lookDirection = new Vector2(1, 0);
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;
    public float checkRadius;
    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    bool isFacingLeft;
    public float addGrav;
    public AudioSource audioSource;
    public AudioSource deathAudioSource;
    public AudioClip jump;
    public AudioClip damageTaken;
    public AudioClip shoot;
    public AudioClip gameOver;

    public TextMeshProUGUI health;

    float dirX; 

    
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         audioSource = GetComponent<AudioSource>();
         SetHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
       inputHorizontal = Input.GetAxis("Horizontal");
       rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
               Jump(); 
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameObject b = Instantiate(ProjectilePrefab);
           b.GetComponent<Bullet>().StartShoot(isFacingLeft);
           b.transform.position = firePoint.transform.position;
           audioSource.PlayOneShot(shoot);
        }
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, groundlayer);
        if (isTouchingFront == true && isGrounded == false && inputHorizontal !=0)
        {
            wallSliding = true;
        } else {
            wallSliding = false;
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        if (Input.GetKeyDown(KeyCode.W) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }
        if (wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce * -inputHorizontal, yWallForce);
        }
    }
    void Jump()
    {
      rb.velocity = new Vector2(rb.velocity.x, 14f);
      audioSource.PlayOneShot(jump);
            
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.2f,groundlayer);
        if (inputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
            firePoint.transform.localScale = new Vector3(1,1,1);
            isFacingLeft = false;
            
           
        }
        if (inputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
            firePoint.transform.localScale = new Vector3(-1,1,1);
            isFacingLeft = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "enemy")
        {
            healthPoints = healthPoints -1;
             SetHealthText();
            audioSource.PlayOneShot(damageTaken);
            if (healthPoints <= 0)
        {
            healthPoints = 0;
             gameObject.transform.localScale = new Vector3(0.1f,0.1f,1);
             deathAudioSource.clip = gameOver;

            deathAudioSource.Play();
        }
        }

    }
    void Flip()
    {
        Vector3 currentScale =  gameObject.transform.localScale;
    }
    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }
    void SetHealthText()
    {
        health.text = "Health: " + healthPoints.ToString() + "/3";
    }
}
