using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int GainHealthAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            other.GetComponent<Health>().GainHealth(Mathf.Clamp(GainHealthAmount, 1, 3) / 10);
        }
    }
}
