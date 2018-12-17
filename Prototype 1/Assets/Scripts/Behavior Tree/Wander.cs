using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Node
{
    public override Result Execute(EnemyBehaviorTree EBT)
    {

        Debug.Log("WANDERING SUCCESS");
        return Result.success;
    }
}
