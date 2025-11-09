using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class _EnemyAI : MonoBehaviour
    {
        [Header("AI Settings")]
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private float detectionRange = 5f; // The range at which the enemy detects the player.
        [SerializeField] private float followDuration = 3f; // The duration the enemy follows the player.
        [Header("Components")]
        [SerializeField] private LayerMask ground;
        [SerializeField] private LayerMask wall;
        // references 
        private new Rigidbody2D rigidbody;
        private Collider2D triggerCollider;
        private Transform player;
        private bool isFollowingPlayer = false;
        private float followTimer = 0f;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            triggerCollider = GetComponent<Collider2D>();
            player = GameObject.FindGameObjectWithTag("Player")?.transform; // Safely get the player transform
        }
        void Update()
        {
            if (player != null)
            {
                // Check if the player is in range
                if (IsPlayerInRange() && !isFollowingPlayer)
                {
                    isFollowingPlayer = true;
                    followTimer = followDuration;

                    Debug.LogWarning("Player in range");

                }

                // Follow the player if following
                if (isFollowingPlayer)
                {
                    FollowPlayer();
                }
                else
                {
                    // Move normally if not following the player
                    Move();
                }
            }
            else
            {
                Debug.LogWarning("Player not found! Ensure there is a GameObject with the 'Player' tag.");
            }
        }
        void FixedUpdate()
        {
            // Handle wall detection and flipping
            if (!triggerCollider.IsTouchingLayers(ground) || triggerCollider.IsTouchingLayers(wall))
            {
                Flip();
            }
        }

        private void FollowPlayer()
        {
            Debug.LogWarning("start Follow");

            if (followTimer > 0)
            {
                // Calculate direction to the player and move towards them
                float direction = (player.position.x - transform.position.x > 0) ? -1 : 1;
                rigidbody.linearVelocity = new Vector2(moveSpeed * direction, rigidbody.linearVelocity.y);
                followTimer -= Time.fixedDeltaTime; // Use Time.fixedDeltaTime for physics updates
            }
            else
            {
                isFollowingPlayer = false;
                Debug.LogWarning("stop Follow");
            }
        }
        private bool IsPlayerInRange()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            return distanceToPlayer <= detectionRange;
        }

        private void Move()
        {
            rigidbody.linearVelocity = new Vector2(moveSpeed, rigidbody.linearVelocity.y);
        }

        private void Flip()
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y); // Flip the enemy
            moveSpeed *= -1; // Change direction
        }
    }
}
