using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : BossNode
{

    public override Result Execute(BossBehaviorTree BBT)
    {

        
        if (BBT.CheckingDistanceMaximum() && !BBT.CheckingDistanceMinimum())// Checking if close
        {
            BBT.transform.LookAt(BBT.player.transform);
            Vector3 enemyPosition = (BBT.player.gameObject.transform.position - BBT.transform.position).normalized;
            Vector3 Distance = new Vector3(enemyPosition.x, 0, enemyPosition.z);
            BBT.transform.position += Distance * BBT.enemySpeed * Time.deltaTime * 0.1f;
            BBT.moving = true;
            BBT.anim.SetBool("Attack", false);
            BBT.anim.SetBool("Idle", false);
            BBT.anim.SetBool("Chase", true);
            BBT.anim.SetBool("Die", false);

            if (BBT.CheckingDistanceMinimum())// Checking if right next to him
            {
                BBT.moving = false;
                return Result.success;  
            }
        }
        else if (BBT.CheckingDistanceMinimum())// Checking if right next to him
        {
            BBT.moving = false;
            return Result.success;
        }
        
        return Result.failure;
    }
}