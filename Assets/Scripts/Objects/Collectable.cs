using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int GainHealthAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Item collected ");
            collision.GetComponent<Health>().AddHealth(GainHealthAmount);
            gameObject.SetActive(false);
        }
    }
}
