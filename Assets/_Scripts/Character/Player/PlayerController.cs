using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //move var
    public float maxSpeed;

    public Joystick joystick;

    //jump var
    bool grounded = false;
    bool isJumping = false;
    float groundCheckerRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float jumpHeight;


    Rigidbody2D montu;
    Animator montuAnim;
    bool facingRight;

    //shoot var
    public GameObject bullet;
    public Transform gunTip;
    public float fireRate = 0.05f;
    float nextFire = 0.0f;

    void Start()
    {
        montu = GetComponent<Rigidbody2D>();
        montuAnim = GetComponent<Animator>();

        facingRight = true;
    }

    void Update()
    {
        if (grounded && isJumping)
        {
            grounded = false;
            isJumping = false;
            montuAnim.SetBool("isGrounded", grounded);
            montu.AddForce(new Vector2(0, jumpHeight));
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckerRadius, groundLayer);
        montuAnim.SetBool("isGrounded", grounded);
        montuAnim.SetFloat("verticalSpeed", montu.velocity.y);

        float move = joystick.Horizontal;
        montuAnim.SetFloat("speed", Mathf.Abs(move));

        montu.velocity = new Vector2(move * maxSpeed, montu.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

    }

    void flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

    public void Jump()
    {
        isJumping = true;
    }

    public void fireBullet()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Platform")
        {
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Platform")
        {
            transform.parent = null;
        }
    }

}
