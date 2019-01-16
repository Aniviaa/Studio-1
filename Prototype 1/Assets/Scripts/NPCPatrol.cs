using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    public Animator npcAnimator;
    public bool lookAtTarget;
    public bool enemyMoving;
    public float idleTime;
    public int randomPatrolSpot;
    public Transform[] patrolSpots;
    public int npcSpeed;

    // Start is called before the first frame update
    void Start()
    {
        randomPatrolSpot = 0;
        npcAnimator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {


        npcAnimator.SetBool("Idle", false);
        npcAnimator.SetBool("Walk", true);

        lookAtTarget = true;

        if (lookAtTarget)
        {
            if (randomPatrolSpot >= patrolSpots.Length)
            {
                randomPatrolSpot = 0;
            }
            transform.LookAt(patrolSpots[randomPatrolSpot].position);
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolSpots[randomPatrolSpot].position, npcSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, patrolSpots[randomPatrolSpot].position) <= 0.1)
        //This is so that when the enemy gets to the patrol spot, it stops even if it doesnt EXACTLY hit the
        {
            if (idleTime <= 0)
            {

                lookAtTarget = true;

                randomPatrolSpot++;

                idleTime = 3;
            }

            else
            {
                idleTime -= Time.deltaTime;
                lookAtTarget = false;
                npcAnimator.SetBool("Idle", true);
                npcAnimator.SetBool("Walk", false);
            }
        }
    }
}
