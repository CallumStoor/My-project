using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float attackCooldown;
    [Header("Set Components")]
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField ]private BoxCollider2D _boxCollider;
    // Refreances
    private Animator anim;
    private PlayerMovement playerMovement;
    private float airAttackModifier = 0;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown)
            {
                if (playerMovement.canAirAttack())
                {
                    anim.SetTrigger("attack");
                    airAttackModifier = 0;
                }
                else
                {
                    anim.SetTrigger("airAttack");
                    airAttackModifier = 0.3f;
                }
            }
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack() // called with animation event
    {
        cooldownTimer = 0;

        Health target = attackHit();
        if (target != null)
        {
            target.TakeDamage(1);
            Debug.Log("Enemy Hit");
        }
    }

    private Health attackHit()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
        _boxCollider.bounds.center,
        new Vector3(_boxCollider.size.x * attackRange + airAttackModifier, _boxCollider.size.y + (airAttackModifier * 2), 1),
        0,
        new Vector2(Mathf.Sign(transform.localScale.x) * colliderDistance - airAttackModifier, 0 - airAttackModifier),
        1f,
        enemyLayer);

        return hit.collider != null ? hit.transform.GetComponent<Health>() : null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            new Vector3(_boxCollider.bounds.center.x + Mathf.Sign(transform.localScale.x) * colliderDistance - airAttackModifier, _boxCollider.bounds.center.y - airAttackModifier, _boxCollider.bounds.center.z),
            new Vector2(_boxCollider.size.x * attackRange + airAttackModifier, _boxCollider.size.y + (airAttackModifier * 2)));
    }

}
