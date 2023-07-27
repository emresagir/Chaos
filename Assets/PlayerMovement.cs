using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    //bool isJumping;
    private bool isAbleToJump;
    private int jumpCount;


    [SerializeField] private float distToGround;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Wassaa");
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        //isJumping = false;
        isAbleToJump = false;

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded();
        if (Input.GetKeyDown("w") && isAbleToJump) //Jump
        {
            jump();

        }
        else if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-1*speed,rb.velocity.y);
        }
    }


    private void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 12);
        jumpCount++;
        if (jumpCount > 0)
        {
            isAbleToJump = false;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");
        if (collision.gameObject.tag == "Ground")
            isJumping = false;
        Debug.Log("ground is being touched");
    }
    */

    private void isGrounded()
    {
        bool bc = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, distToGround, jumpableGround);
        if (bc == true)
        {
            jumpCount = 0;
            isAbleToJump = true;
        }
    }

}
