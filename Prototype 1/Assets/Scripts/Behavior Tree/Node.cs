using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> childrenNodes = new List<Node>();

    public enum Result { ready, running, success, failure};

    public virtual Result Execute(EnemyBehaviorTree EBT)
    {
        return Result.running;
    }
}