using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float atttackCooldown;
    [SerializeField] private LayerMask enemyLayer;
    private Animator anim;
    private BoxCollider2D _boxCollider;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.GetMouseButtonDown(0) && cooldownTimer > atttackCooldown && playerMovement.canAttack())
            {
                anim.SetTrigger("attack");
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
        _boxCollider.bounds.size,
        0,
        new Vector2(Mathf.Sign(transform.localScale.x), 0),
        1f,
        enemyLayer
    );

        if (hit.collider != null)
        {
            Debug.DrawLine(_boxCollider.bounds.center, hit.point, Color.red, 0.1f);
            return hit.collider.GetComponent<Health>();
        }

        return null;
    }

}
