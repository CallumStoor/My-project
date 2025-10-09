using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed = 2f;
    private Rigidbody2D body;
    private Animator anim;
    private bool isGrounded;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < 0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        body.linearVelocity = new Vector2(horizontalInput * speed * Time.deltaTime, body.linearVelocity.y);

        if(Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        anim.SetBool("run", horizontalInput != 0);
    }

    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }

        
    }

}
