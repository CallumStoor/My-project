using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int GainHealthAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.GetComponent<SpriteRenderer>().color = Color.green;
            collision.GetComponent<Health>().AddHealth(Mathf.Clamp(GainHealthAmount, 1, 3) / 10);
            Invoke("_Wait", 1);
            collision.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    private void _Wait()
    {

    }
}
