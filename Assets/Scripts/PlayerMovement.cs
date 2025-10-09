using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed = 12f;
    [SerializeField] private float jumpHieght = 25f;
    private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator anim;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
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

        if(Input.GetKey(KeyCode.Space) && isGrounded() == true)
        {
            Jump();
        }

        anim.SetBool("run", horizontalInput != 0);
        anim.SetTrigger("jump");
        anim.SetBool("isGrounded", isGrounded());
    }

    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed * jumpHieght * Time.deltaTime);
        isGrounded() = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded() = true;
        }     
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
    }

}
// 4:44