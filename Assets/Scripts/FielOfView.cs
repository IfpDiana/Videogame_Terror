using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FielOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionmask;

    public bool canSeePlayer;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FielOfViewCheck();
        }
    }

    private void FielOfViewCheck()
    {
        Collider[] rangechecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangechecks.Length != 0)
        {
            Transform target = rangechecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionmask))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }       
            }
            else
            {
                canSeePlayer = false;
            }
                
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
            
    }

    private void Update()
    {
        FielOfViewCheck();
    }
}
