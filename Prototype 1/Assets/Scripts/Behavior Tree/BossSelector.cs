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
                Debug.Log("Selector Success");
                return Result.success;
            }


            else if (childrenNodes[i].Execute(BBT) == Result.running)
            {
                //currentResult = Result.running;
                Debug.Log("Selector Running");
                childrenNodes[i].Execute(BBT);
            }
        }

        //currentResult = Result.failure;
        Debug.Log("Selector Failed");
        return Result.failure;

    }

}
