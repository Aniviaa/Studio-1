using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Node

{ 

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (EBT.CheckingDistanceMaximum() || EBT.patrolSpots.Length == 0)// Checking if close
        {
            return Result.failure;
        }
        else
        {
            EBT.enemyAnimator.SetBool("Attack", false);
            EBT.enemyAnimator.SetBool("Idle", false);
            EBT.enemyAnimator.SetBool("Walk", true);
            EBT.enemyAnimator.SetBool("Dead", false);

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
        }
        return Result.success;
    }
}