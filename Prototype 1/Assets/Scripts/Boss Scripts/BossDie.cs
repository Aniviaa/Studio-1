using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDie : BossNode
{
    public override Result Execute(BossBehaviorTree BBT)
    {
        if (BBT.GetComponent<EnemyScript>().enemyHealth > 0)
        {
            return Result.failure;
        }
        else
        {
            BBT.player.GetComponent<PlayerController>().currentEnemy = null;

            BBT.transform.LookAt(BBT.player.transform.position);

            BBT.anim.SetBool("Attack", false);
            BBT.anim.SetBool("RangedAttack", false);
            BBT.anim.SetBool("Idle", false);
            BBT.anim.SetBool("Chase", false);
            BBT.anim.SetBool("Die", true);
            BBT.fireAttack.SetActive(false);
            BBT.GetComponent<BossBehaviorTree>().enabled = false;
            return Result.success;
        }
    }
}