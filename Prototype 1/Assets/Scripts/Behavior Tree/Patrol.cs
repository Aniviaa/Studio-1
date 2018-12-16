using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Node

{ 

    public override void Execute(EnemyBehaviorTree EBT)
    {
        if (EBT.patrolSpots.Length == 0)
        {
            currentResult = Result.failure;
        }
        else if (Vector3.Distance(EBT.transform.position, EBT.player.transform.position) < EBT.minimumDistance)// Checking if close
        {
            currentResult = Result.failure;
            Debug.Log("PATROLLING FAILED");
        }
        else
        {

            
            EBT.lookAtTarget = true;
            if (EBT.lookAtTarget)
            {
                EBT.transform.LookAt(EBT.patrolSpots[EBT.randomPatrolSpot].position);
            }
            EBT.enemyMoving = true;
            EBT.transform.position = Vector3.MoveTowards(EBT.transform.position, EBT.patrolSpots[EBT.randomPatrolSpot].position, EBT.enemySpeed * Time.deltaTime);

            if (Vector3.Distance(EBT.transform.position, EBT.patrolSpots[EBT.randomPatrolSpot].position) <= 10)
            //This is so that when the enemy gets to the patrol spot, it stops even if it doesnt EXACTLY hit the
            {
                EBT.enemyMoving = false;
                if (EBT.idleTime <= 0)
                {
                    EBT.enemyMoving = true;
                    EBT.lookAtTarget = true;
                    EBT.randomPatrolSpot = Random.Range(0, EBT.patrolSpots.Length);
                    EBT.idleTime = EBT.patrolTime;
                }

                else
                {
                    EBT.enemyMoving = false;
                    EBT.idleTime -= Time.deltaTime;
                    EBT.lookAtTarget = false;
                    EBT.enemyAnimator.SetBool("Attack", false);
                    EBT.enemyAnimator.SetBool("Idle", true);
                    EBT.enemyAnimator.SetBool("Walk", false);
                    EBT.enemyAnimator.SetBool("Dead", false);
                }
            }

            currentResult = Result.running;


        }
    }
}
