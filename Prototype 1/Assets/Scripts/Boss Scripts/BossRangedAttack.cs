using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRangedAttack : BossNode
{
    public override Result Execute(BossBehaviorTree BBT)
    {
        

        if (Vector3.Distance(BBT.transform.position, BBT.player.transform.position) <= BBT.minimumDistance
            && BBT.GetComponent<EnemyScript>().enemyHealth > 0 && BBT.attackRange >= 6 && BBT.attackTime >= 2 && !BBT.moving)

        {

            BBT.anim.SetBool("Idle", false);
            BBT.anim.SetBool("Attack", true);
            BBT.anim.SetBool("Chase", false);
            BBT.anim.SetBool("Die", false);
            BBT.player.GetComponent<PlayerController>().playerHealth -= BBT.GetComponent<EnemyScript>().enemyAttack;
            //Instantiate(EBT.arrow, EBT.arrowPositions.transform.position, Quaternion.identity);
            //BBT.objectPool.Fire(BBT.arrowPositions);
            if (BBT.attackTime >= 4)
            {
                BBT.attackTime = 0;
            }
            Debug.Log("Ranged Attack");
            return Result.success;
        }
        else
        {
            Debug.Log("Ranged Attack failed");
            return Result.failure;
        }
    }

}
