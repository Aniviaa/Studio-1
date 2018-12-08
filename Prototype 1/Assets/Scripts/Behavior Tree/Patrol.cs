using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    //GameObject player;
    public Animator enemyAnimator;
    public Transform[] patrolSpots;
    public int randomPatrolSpot;
    public float enemySpeed;
    //public int minimumDistance;
    //int maximumDistance;
    //public bool dead;
    //bool done;
    public bool enemyMoving;
    public bool lookAtTarget;
    public float idleTime;
    public float patrolTime;
    //public float Mass = 15;
    //public float MaxVelocity = 10;
    //public float MaxForce = 15;

    public void EnemyPatrol()
    {
        lookAtTarget = true;
        if (lookAtTarget)
        {
            gameObject.transform.LookAt(patrolSpots[randomPatrolSpot].position);
        }
        enemyMoving = true;
        transform.position = Vector3.MoveTowards(transform.position, patrolSpots[randomPatrolSpot].position, enemySpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, patrolSpots[randomPatrolSpot].position) <= 10) //This is so that when the enemy gets to the patrol spot, it stops even if it doesnt EXACTLY hit the 
        {
            enemyMoving = false;
            if (idleTime <= 0)
            {
                enemyMoving = true;
                lookAtTarget = true;
                randomPatrolSpot = Random.Range(0, patrolSpots.Length);
                idleTime = patrolTime;
            }

            else
            {
                enemyMoving = false;
                idleTime -= Time.deltaTime;
                lookAtTarget = false;
                enemyAnimator.SetBool("Attack", false);
                enemyAnimator.SetBool("Idle", true);
                enemyAnimator.SetBool("Walk", false);
                enemyAnimator.SetBool("Dead", false);
            }
        }
    }
}
