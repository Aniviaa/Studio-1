using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNode : MonoBehaviour
{
    public List<BossNode> childrenNodes = new List<BossNode>();

    public enum Result { ready, running, success, failure };

    public virtual Result Execute(BossBehaviorTree BBT)
    {
        return Result.running;
    }
}