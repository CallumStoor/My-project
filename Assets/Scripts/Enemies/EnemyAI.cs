using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int detectionRange = 5;
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject JumpDetection;
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

        if (playerDistance <= detectionRange && !meleeEnemy.canAttack && playerDistance >= 2)
        {
            anim.SetBool("run", true);
            rb.linearVelocity = new Vector2(playerDistance * moveSpeed * PlayerDirection(), rb.linearVelocity.y);
            
            if (CanJump())
            {
                Debug.Log("Enemy Jumped");
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 7f);
            }
            
        }
        else
        {
            anim.SetBool("run", false);
            rb.linearVelocity = Vector2.zero;
        }
        

    }

    private bool CanJump()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(JumpDetection.transform.position, Vector2.right * PlayerDirection(), 2f, LayerMask.GetMask("Ground"));
        if (raycastHit.collider != null)
        {
            return true;
        }
        return false;
    }

    private int PlayerDirection()
    {
        if (playerTransform.position.x < transform.position.x)
            return -1;
        else
            return 1;
    }




}
