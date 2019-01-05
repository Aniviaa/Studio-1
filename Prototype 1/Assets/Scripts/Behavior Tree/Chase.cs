using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Node
{

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (EBT.CheckingDistanceMaximum() && !EBT.CheckingDistanceMinimum())// Checking if close
        {
            EBT.transform.LookAt(EBT.player.transform);
            Vector3 enemyPosition = (EBT.player.gameObject.transform.position - EBT.transform.position).normalized;
            Vector3 Distance = new Vector3(enemyPosition.x, 0, enemyPosition.z);
            EBT.transform.position += Distance * EBT.enemySpeed * Time.deltaTime;

            EBT.enemyAnimator.SetBool("Attack", false);
            EBT.enemyAnimator.SetBool("Idle", false);
            EBT.enemyAnimator.SetBool("Walk", true);
            EBT.enemyAnimator.SetBool("Dead", false);


            if (EBT.CheckingDistanceMinimum())// Checking if right next to him
            {
                return Result.success;
            }
        }
        else if (EBT.CheckingDistanceMinimum())// Checking if right next to him
        {
            Debug.Log("Chase Succeed");
            return Result.success;
        }
        Debug.Log("Chase Failed");
        return Result.failure;
    }
}