using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : Node
{ 
    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (EBT.GetComponent<EnemyScript>().enemyHealth > 0)
        {
            return Result.failure;
        }
        else
        {
            EBT.player.GetComponent<PlayerController>().currentEnemy = null;

            EBT.transform.LookAt(EBT.player.transform.position);

            EBT.enemyAnimator.SetBool("Attack", false);
            EBT.enemyAnimator.SetBool("Idle", false);
            EBT.enemyAnimator.SetBool("Walk", false);
            EBT.enemyAnimator.SetBool("Dead", true);

            Debug.Log("Enemy Died");

            return Result.success;
        }
    }
}