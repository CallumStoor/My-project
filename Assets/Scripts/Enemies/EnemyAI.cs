using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int detectionRange = 5;
    [SerializeField] Transform playerTransform;
    private Rigidbody2D rb;
    private Animator anim;
    private float playerDistance;
    private MeleeEnemy meleeEnemy;

    private void Awake()
    {
        if(gameObject.GetComponent<MeleeEnemy>() != null)
            meleeEnemy = gameObject.GetComponent<MeleeEnemy>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerDistance = Vector2.Distance(transform.position, playerTransform.position);

        transform.localScale = new Vector3(PlayerDirection(), 1, 1);

        if (playerDistance <= detectionRange && !meleeEnemy.canAttack)
        {
            anim.SetTrigger("run");
            rb.linearVelocity = new Vector2(playerDistance * moveSpeed * PlayerDirection(), rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private int PlayerDirection()
    {
        if (playerTransform.position.x < transform.position.x)
            return -1;
        else
            return 1;
    }




}
