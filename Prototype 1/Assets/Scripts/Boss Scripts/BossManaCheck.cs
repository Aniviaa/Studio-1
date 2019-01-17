using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManaCheck : BossNode
{
    public override Result Execute(BossBehaviorTree BBT)
    {
        if (BBT.mana > 30)
        {
            BBT.minimumDistance = 15;
            BBT.attackRange = 0;
            Debug.Log("Mana Node Success");
            return Result.success;
        }
        else
        {
            BBT.minimumDistance = 5;
            BBT.attackRange = 1;
            Debug.Log("Mana Node Success 2");
            return Result.success;
        }
    }
}
