using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSelector : BossNode
{

    public override Result Execute(BossBehaviorTree BBT)
    {
        for (int i = 0; i < childrenNodes.Count; i++)
        {
            if (childrenNodes[i].Execute(BBT) == Result.success)
            {
                //currentResult = Result.success;
                return Result.success;
            }


            else if (childrenNodes[i].Execute(BBT) == Result.running)
            {
                childrenNodes[i].Execute(BBT);
            }
        }

        //currentResult = Result.failure;
        return Result.failure;

    }

}
