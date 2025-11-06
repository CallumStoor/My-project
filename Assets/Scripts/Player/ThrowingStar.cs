using UnityEngine;

public class ThrowingStar : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("star collided");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            gameObject.SetActive(false);
        }
    }
}
