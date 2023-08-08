using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anima;
    private SpriteRenderer spriteRend;
    //bool isJumping;
    private bool isAbleToJump;
    private int jumpCount;
    private GameObject flamator;
    private SpriteRenderer flamatorRend;


    [SerializeField] private float distToGround;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Wassaa");
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anima = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        //isJumping = false;
        isAbleToJump = false;

        //flamator is searching, thus at the second jump there will be a flame on the bottom of the char.
        flamator = GameObject.Find("Flamator");
        flamatorRend = flamator.GetComponent<SpriteRenderer>();

        

    }

    // Update is called once per frame
    void Update()
    {

        /////////////////////KEY CHECK///////////////////////
        isGrounded();
        if (Input.GetKeyDown("w") && isAbleToJump) //Jump
        {
            jump();

        }
        else if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            anima.SetBool("isRunning", true);
            spriteRend.flipX = false;
        }
        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-1*speed,rb.velocity.y);
            anima.SetBool("isRunning", true);
            spriteRend.flipX = true;
        }
        else if (Input.GetKey("j"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 12);
            flamatorRend.enabled = true;


        }

        else
        {
            rb.velocity = new Vector2 (0,rb.velocity.y); // this part requires for sliding to stop. If sliding is ok delete this else.
            anima.SetBool("isRunning", false); // runs idle animation
            flamatorRend.enabled = false;
        }
        //////////////////////KEY CHECK END///////////////////////


    }


    private void jump() // for double, triple etc. jump.
    {
        anima.SetBool("isJumping", true);
        rb.velocity = new Vector2(rb.velocity.x, 12);
        jumpCount++;
        if (jumpCount > 0)
        {
            isAbleToJump = false;
        }
    }
    //isGrounded function has a boxcast function in it and it runs with an offset, 
    //when we press the jump key, animation starts but at the same time it enters the 
    //isGrounded function because of the offset. Thus this function used for animation control.
    /*private void OnCollisionEnter2D(Collision2D collision)
                                                            
    {
        Debug.Log("Collision detected");
        if (collision.gameObject.tag == "Ground")
            anima.SetBool("isJumping", false);
        Debug.Log("ground is being touched");
    }
    */

    private void isGrounded() //Ground check with Boxcast function, it returns when casted box collides with wanted layer.
    {
        bool bc = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, distToGround, jumpableGround);
        if (bc == true)
        {
            anima.SetBool("isJumping", false);
            jumpCount = 0;
            isAbleToJump = true;
        }
        else
        {
            anima.SetBool("isJumping", true);
        }
    }

}
