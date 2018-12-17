using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRange : Node {

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (EBT.CheckingDistanceMaximum()) // Checking if its too far
        {
            return Result.failure;
        }
        else if (EBT.CheckingDistanceMinimum())// Checking if its close enough
        {
            return Result.success;
        }
        return Result.success;
    }
}
