using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiLocomotion : MonoBehaviour
{
    public Transform player;
    public float zombieSpeed = 3.0f;
    public float attackRange = 1.0f;
    public NavMeshAgent agent;
    private Animator animator;  
    private PlayerHealth playerHealth;

    public float attackCooldown = 1.0f;  
    private float attackTimer = 0.0f;  

    private bool isAttacking = false;
    private bool isInRange = false;



    void Start()
    {

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");


        if (playerObject != null)
        {
            player = playerObject.transform;
            playerHealth = playerObject.GetComponent<PlayerHealth>();

        }
        else
        {

            return;
        }


        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {



        if (player == null || agent == null || animator == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < attackRange)
        {
            agent.isStopped = true;

        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetBool("Attacking", true);
        }

        if (attackTimer <= 0)
        {
            attackTimer = attackCooldown;
            playerHealth.TakeDamage(10);
        }

        
    }
    else
    {
        
        agent.isStopped = false;
        animator.SetBool("Attacking", false);
        agent.SetDestination(player.position);

        if (isAttacking && !isInRange)
        {
            isAttacking = false;
            animator.SetBool("Attacking", false);
            
            animator.SetBool("Running", true);
        }
    }

    isInRange = distance < attackRange;

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
    }
}

