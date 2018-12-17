using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Node
{

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (EBT.CheckingDistanceMaximum())// Checking if close
        {
            EBT.transform.LookAt(EBT.player.transform);
            Vector3 enemyPosition = (EBT.player.gameObject.transform.position - EBT.transform.position).normalized;
            Vector3 Distance = new Vector3(enemyPosition.x, 0, enemyPosition.z);
            EBT.transform.position += Distance * EBT.enemySpeed * Time.deltaTime;

            EBT.enemyAnimator.SetBool("Attack", false);
            EBT.enemyAnimator.SetBool("Idle", false);
            EBT.enemyAnimator.SetBool("Walk", true);
            EBT.enemyAnimator.SetBool("Dead", false);

            Debug.Log("Chasing");

            if (EBT.CheckingDistanceMinimum())// Checking if right next to him
            {
                Debug.Log("Chase Sucess");
                return Result.success;
            }
        }
        return Result.failure;
    }
}