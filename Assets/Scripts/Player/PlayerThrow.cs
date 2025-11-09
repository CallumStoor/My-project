using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int force = 1;
    public float attackCooldown;

    [Header("Components")]
    [SerializeField] private GameObject throwingStar;
    [SerializeField] private Transform firePoint;
    // reference 
    private Animator starAnimator;
    private float horizontalInput; 
    public float cooldownTimer { get; private set; } = Mathf.Infinity;
    private Rigidbody2D StarRb;
    private Rigidbody2D playerRb;
    public ThrowingStar throwScript { get; private set; }
    private Vector3 shootDirection;


    private void Awake()
    {
        StarRb = throwingStar.GetComponent<Rigidbody2D>();
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        throwScript = throwingStar.GetComponent<ThrowingStar>();
        starAnimator = throwingStar.GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        cooldownTimer += Time.deltaTime;

        shootDirection = (Input.mousePosition - Camera.main.WorldToScreenPoint(firePoint.position)).normalized;

        if (Input.GetMouseButtonDown(1) && cooldownTimer > attackCooldown)
        {
            ResetStar();
            ThrowStar();
        }
        if(Input.GetKeyDown(KeyCode.E) && throwScript.isThrown == true)
        {
            Debug.Log(throwScript.isThrown);
            TeleportToStar();
        }
    }

    private void ThrowStar()
    {
        throwScript.isThrown = true;
        // ensure no leftover velocity
        StarRb.linearVelocity = Vector2.zero;
        StarRb.angularVelocity = 0f;

        // apply an impulse in the aim direction (changes to ForceMode2D.Impulse for immediate throw)
        StarRb.AddForce( new Vector2(shootDirection.x * force, shootDirection.y * force) + (gameObject.GetComponent<Rigidbody2D>().linearVelocity / 4), ForceMode2D.Impulse);

        cooldownTimer = 0;
    }

    private void ResetStar()
    {
        StarRb.bodyType = RigidbodyType2D.Dynamic;
        throwingStar.transform.position = firePoint.position;
        throwingStar.SetActive(true);
        StarRb.linearVelocity = Vector3.zero;
        
    }

    private void TeleportToStar()
    {
        throwScript.isThrown = false;
        playerRb.linearVelocity = Vector2.zero;
        gameObject.transform.position = new Vector3(throwingStar.transform.position.x, throwingStar.transform.position.y + 0.5f, gameObject.transform.position.z);
        playerRb.AddForce(new Vector2(shootDirection.x * (force + 5), shootDirection.y * force), ForceMode2D.Impulse);
    }
}
