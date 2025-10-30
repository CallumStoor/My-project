using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float speed = 2f;
    [SerializeField] private float attackcooldown = 1f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float range = 1f;
    [SerializeField] private float colliderDistance = 1f;
    [Header("Set Components")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private BoxCollider2D boxCollider;
    private float cooldownTimer = Mathf.Infinity;
    // References
    private Rigidbody body; 
    private Animator anim;
    private Health playerHealth;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(cooldownTimer >= attackcooldown)
        {
            if (isPlayerInSight())
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
                // Attack logic here
                Debug.Log("Enemy attacks for " + damage + " damage!");
            }
        }
    }

    private bool isPlayerInSight()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 
            1f, 
            LayerMask.GetMask("Player"));

        if(raycastHit.collider != null)
        {
            playerHealth = raycastHit.transform.GetComponent<Health>();
        }

        return raycastHit.collider != null; 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (isPlayerInSight())
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("Player takes " + damage + " damage!");
        }
    }
}
