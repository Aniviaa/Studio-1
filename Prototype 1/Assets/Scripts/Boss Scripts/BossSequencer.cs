using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSequencer : BossNode
{

    public override Result Execute(BossBehaviorTree BBT)
    {
        for (int i = 0; i < childrenNodes.Count; i++)
        {
            if (childrenNodes[i].Execute(BBT) == Result.running)
            {
                childrenNodes[i].Execute(BBT);
                Debug.Log("Sequence running");
                return Result.running;
                
            }

            else if (childrenNodes[i].Execute(BBT) == Result.failure)
            {
                Debug.Log("Sequence failed");
                return Result.failure;
            }
        }
        Debug.Log("Sequence success");
        return Result.success;
    }
}
