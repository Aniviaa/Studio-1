using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Node
{

    public override void Execute(EnemyBehaviorTree EBT)
    {
        if (Vector3.Distance(EBT.transform.position, EBT.player.transform.position) <= EBT.minimumDistance)
        {
            Debug.Log("Attack Running");
            EBT.enemyAnimator.SetBool("Attack", true);
            EBT.enemyAnimator.SetBool("Idle", false);
            EBT.enemyAnimator.SetBool("Walk", false);
            EBT.enemyAnimator.SetBool("Dead", false);
            EBT.player.GetComponent<PlayerController>().playerHealth -= EBT.GetComponent<EnemyScript>().enemyAttack;

            currentResult = Result.running;

            if (EBT.player.GetComponent<PlayerController>().playerHealth <= 0)// Checking if player is dead
            {
                currentResult = Result.success;
            }
            else if (Vector3.Distance(EBT.transform.position, EBT.player.transform.position) >= EBT.maximumDistance) // Checking if its too far
            {
                currentResult = Result.failure;
            }
        }

        else if (Vector3.Distance(EBT.transform.position, EBT.player.transform.position) >= EBT.maximumDistance) // Checking if its too far
        {
            currentResult = Result.failure;
        }
    }
}
