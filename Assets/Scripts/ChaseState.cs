using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    Animator anim;
    public bool playerInShightRange, playerInAttackRange;
    public float sightRange, attackRange;
    [SerializeField] private  NavMeshAgent agent;
    public PlayerController Player;
    public Transform player;
    public LayerMask whatIsPlayer;
    public AttackState attackState;
    public IdleState idleState;
       
    public override State RunCurrentState()
    {
        agent.SetDestination(player.position);
        if (playerInShightRange && Player.isCrouching) 
        {
            return attackState;
        }
        else
        {
            return idleState;
        }
    }
    public void Update()
    {
        playerInShightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
    }
    //private void Awake()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //    anim = GetComponent<Animator>();
    //}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
