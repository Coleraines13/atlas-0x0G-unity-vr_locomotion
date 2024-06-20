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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        lastAttackTime = -attackCooldown;  // allow immediate attack
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            agent.SetDestination(player.position);

            if (distanceToPlayer <= attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                Attack();
            }
            else
            {
                animator.SetBool("isAttacking", false);
            }

            animator.SetBool("isChasing", true);
        }
        else
        {
            animator.SetBool("isChasing", false);
            agent.SetDestination(transform.position);  // stop moving when player is out of range
        }
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
        lastAttackTime = Time.time;
        // add damage later
    }
 }
