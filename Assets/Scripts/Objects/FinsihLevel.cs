using UnityEngine;

public class FinsihLevel : MonoBehaviour
{
    [SerializeField] private Sprite newSprite;
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            spriteRenderer.sprite = newSprite;
            gameManager.Invoke("NextScene", 1);

        }
    }
}
