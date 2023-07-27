using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    bool isJumping;
    float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Wassaa");
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w") && !isJumping) //Jump
        {
            jump();

        }
        else if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(4, rb.velocity.y);
        }
        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-4, rb.velocity.y);
        }
    }


    private void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 12);
        isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");
        if (collision.gameObject.tag == "Ground")
            isJumping = false;
        Debug.Log("ground is being touched");
    }
}
