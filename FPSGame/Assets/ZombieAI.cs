using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 15f;
    public float attackRange = 2f;
    public float attackCooldown = 2f;

    private NavMeshAgent agent;
    private Animator animator;
    private float lastAttackTime;
    private bool isChasing;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        lastAttackTime = -attackCooldown;  // allow immediate attack

        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found. Ensure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Debug.Log("Distance to player: " + distanceToPlayer);

        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
            Debug.Log("Player detected. Starting chase.");
        }
        else
        {
            isChasing = false;
            Debug.Log("Player out of range. Stopping chase.");
            animator.SetBool("isChasing", false);
            agent.SetDestination(transform.position);  // stop moving when player is out of range
            return;  // exit Update to prevent further execution
        }

        if (isChasing)
        {
            agent.SetDestination(player.position);
            animator.SetBool("isChasing", true);
            Debug.Log("Chasing player.");

            if (distanceToPlayer <= attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                Debug.Log("In attack range. Attacking player.");
                Attack();
            }
            else
            {
                Debug.Log("Not in attack range or cooldown active. Cannot attack.");
                animator.SetBool("isAttacking", false);
            }
        }
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
        lastAttackTime = Time.time;
        Debug.Log("Attacking player. Attack cooldown started.");
        // add damage later
    }

    public bool IsAttacking()
    {
        return animator.GetBool("isAttacking");
    }
}