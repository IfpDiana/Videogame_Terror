using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent nAgent;

    private void Start()
    {
        nAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (GetComponent <FielOfView>().canSeePlayer)
        nAgent.SetDestination(target.transform.position); //va a la ultima posición del player
        else nAgent.SetDestination(transform.position);//se queda quieto si sales del cono de visión
    }
}
