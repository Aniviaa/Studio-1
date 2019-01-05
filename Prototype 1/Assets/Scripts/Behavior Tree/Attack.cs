using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Node
{

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (Vector3.Distance(EBT.transform.position, EBT.player.transform.position) <= EBT.minimumDistance 
            && EBT.GetComponent<EnemyScript>().enemyHealth > 0 &&
            !EBT.GetComponent<EnemyScript>().ranged)
        {
            EBT.enemyAnimator.SetBool("Attack", true);
            EBT.enemyAnimator.SetBool("Idle", false);
            EBT.enemyAnimator.SetBool("Walk", false);
            EBT.enemyAnimator.SetBool("Dead", false);
            EBT.player.GetComponent<PlayerController>().playerHealth -= EBT.GetComponent<EnemyScript>().enemyAttack;
            Debug.Log("This Is Normal Attack");

            return Result.success;
        }

        else

        Debug.Log("Normal Attack Failed");
            return Result.failure;
    }
}
