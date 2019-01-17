using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : BossNode
{
    public override Result Execute(BossBehaviorTree BBT)
    {
        if (!BBT.moving)
        {

            BBT.anim.SetBool("Attack", false);
            BBT.anim.SetBool("RangedAttack", false);
            BBT.anim.SetBool("Idle", true);
            BBT.anim.SetBool("Chase", false);
            BBT.anim.SetBool("Die", false);
        }
        Debug.Log("Idle");
        return Result.success;
    }
}
