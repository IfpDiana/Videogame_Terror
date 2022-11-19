using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    public bool playerInShightRange;
    public NavMeshAgent agent;
    public IdleState idleState;
    public float sightRange; 
    public Transform player;
    public PlayerController Player;
    public LayerMask whatIsPlayer;
    public ChaseState chaseState;
    public override State RunCurrentState()
    {
        if (playerInShightRange && !Player.isCrouching) 
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }
    public void Update()
    {
        playerInShightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);       
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
