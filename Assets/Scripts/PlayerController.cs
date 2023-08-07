using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float JumpsAllowed;
    
    private Rigidbody2D rb;
    private float moveInput;
    private bool isJumping;
    private int timesJumped;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timesJumped = 0;
    }

    void FixedUpdate()
    {
        // -1 is left, 0 is still, 1 is right
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Jump only when the Jump button is pressed and the number of jumps is less than JumpsAllowed
        if (Input.GetButtonDown("Jump") && timesJumped < JumpsAllowed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            timesJumped++;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            timesJumped = 0;
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}