﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeAttack : BossNode
{
    
    public override Result Execute(BossBehaviorTree BBT)
    {
        if (Vector3.Distance(BBT.transform.position, BBT.player.transform.position) <= BBT.minimumDistance
            && BBT.GetComponent<EnemyScript>().enemyHealth > 0 && BBT.attackRange <= 5 && BBT.attackTime >= 60 && !BBT.moving)
            
        {
            BBT.anim.SetBool("Attack", true);
            BBT.anim.SetBool("Idle", false);
            BBT.anim.SetBool("Chase", false);
            BBT.anim.SetBool("Die", false);
            BBT.statsScript.playerHealth -= (int)BBT.GetComponent<EnemyScript>().enemyAttack;

            if (BBT.attackTime >= 61)
            {
                BBT.attackTime = 0;
            }

            Debug.Log("Melee Attack");
            return Result.success;
        }

        else
        {
            BBT.attackTime += Time.deltaTime;
            Debug.Log("Mele Attack Failed");
            return Result.failure;
        }

    }
}
