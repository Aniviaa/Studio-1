using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        for (int i = 0; i < childrenNodes.Count; i++)
        {
            if (childrenNodes[i].Execute(EBT) == Result.success)
            {
                //currentResult = Result.success;
                return Result.success;
            }


            else if (childrenNodes[i].Execute(EBT) == Result.running)
            {
                //currentResult = Result.running;
                childrenNodes[i].Execute(EBT);
            }
        }

        //currentResult = Result.failure;
        return Result.failure;

    }

}
