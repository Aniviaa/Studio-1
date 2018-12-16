using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRange : Node {

    public override void Execute(EnemyBehaviorTree EBT)
    {
        if (Vector3.Distance(transform.position, EBT.player.transform.position) >= EBT.maximumDistance) // Checking if its too far
        {
            currentResult = Result.failure;
        }
        else if (Vector3.Distance(transform.position, EBT.player.transform.position) > EBT.minimumDistance)// Checking if its close enough
        {
            currentResult = Result.success;
        }
    }
}
