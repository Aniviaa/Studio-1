using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{

    public override void Execute(EnemyBehaviorTree EBT)
    {
        for (int i = 0; i < childrenNodes.Count; i++)
        {
            if (childrenNodes[i].currentResult == Result.running)
            {
                currentResult = Result.running;
                childrenNodes[i].Execute(EBT);
                return;
            }

            else if (childrenNodes[i].currentResult == Result.success)
            {
                currentResult = Result.success;
                return;
            }
        }

        currentResult = Result.failure;
        return;
    }

}
