using UnityEngine;

public class FinsihLevel : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            gameManager.Invoke("NextScene", 1);
            collision.GetComponent<PlayerMovement>().enabled = false;

        }
    }
}
