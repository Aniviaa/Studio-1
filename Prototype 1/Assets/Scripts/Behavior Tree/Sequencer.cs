using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : Node
{

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        for (int i = 0; i < childrenNodes.Count; i++)
        {
            if (childrenNodes[i].Execute(EBT) == Result.running)
            {
                childrenNodes[i].Execute(EBT);
                return Result.running;
            }

            else if (childrenNodes[i].Execute(EBT) == Result.failure)
            {
                return Result.failure;
            }
        }
        
        return Result.success;
    }
}
