using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Health>() != null)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
