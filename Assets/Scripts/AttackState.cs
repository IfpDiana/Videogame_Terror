using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AttackState : State
{
    Animator anim;
    public bool playerInAttackRange;
    public float attackRange;
    public AttackState attackState;
    public NavMeshAgent agent;
    public PlayerController Player;
    public Transform player;
    public LayerMask whatIsPlayer;
    public ChaseState chaseState;
    public override State RunCurrentState()
    {
        if (playerInAttackRange == true)
        {    
            agent.transform.LookAt(player);
            agent.SetDestination(transform.position);
            return this;
        }
        else
        {
            return chaseState;
        }
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    public void Update()
    {      
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
    }
}
