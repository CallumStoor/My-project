using Unity.VisualScripting;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float angle = 2;
    [SerializeField] private int force = 10;
    [SerializeField] private float attackCooldown;

    [Header("Components")]
    [SerializeField] private GameObject throwingStar;
    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemyLayer;
    // reference 
    private Rigidbody2D rb;
    private float horizontalInput;
    private float cooldownTimer = Mathf.Infinity;


    private void Awake()
    {
        rb = throwingStar.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        cooldownTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(1) && cooldownTimer > attackCooldown)
        {
            ThrowStar();
        }
    }

    private void ThrowStar()
    {
        throwingStar.transform.position = firePoint.position;
        throwingStar.SetActive(true);
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(new Vector2(1 * (angle / 2) * Mathf.Sign(transform.localScale.x), angle) * force / angle);
        rb.AddTorque(angle * 4);
        cooldownTimer = 0;
    }
}
