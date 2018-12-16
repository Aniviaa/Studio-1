using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> childrenNodes = new List<Node>();

    public enum Result { ready, running, success, failure};

    public Result currentResult = Result.running;

    public virtual void Execute(EnemyBehaviorTree EBT)
    {
        Debug.Log("Current State: " + currentResult);
    }
}
