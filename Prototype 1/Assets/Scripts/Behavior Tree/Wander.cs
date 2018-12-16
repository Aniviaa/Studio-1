using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Node
{


    public override void Execute(EnemyBehaviorTree EBT)
    {
        Debug.Log("WANDERING");

        if (Vector3.Distance(EBT.transform.position, EBT.player.transform.position) > EBT.minimumDistance)// Checking if close
        {
            Debug.Log(Vector3.Distance(EBT.transform.position, EBT.player.transform.position));
            currentResult = Result.failure;
        }
    }
}
