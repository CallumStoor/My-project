using UnityEngine;

public class ThrowingStar : MonoBehaviour
{
    private Animator anim;
    public bool isThrown = false;
    public bool hitGround = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!hitGround)
            anim.SetBool("isThrown", isThrown);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("star collided");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            gameObject.SetActive(false);
            isThrown = false; hitGround = false;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            hitGround = true;
            anim.SetBool("isThrown", false);
            Debug.Log("Ground hit");
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            isThrown = true;

        }
    }
}
