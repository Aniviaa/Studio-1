using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorTree : MonoBehaviour{

    public GameObject player;
    public Animator enemyAnimator;
    public Transform[] patrolSpots;
    public int randomPatrolSpot;
    public float enemySpeed;
    public int minimumDistance;
    public int maximumDistance;
    public bool dead;
    public bool done;
    public bool enemyMoving;
    public bool lookAtTarget;
    public float idleTime;
    public float patrolTime;
    public float Mass = 15;
    public float MaxVelocity = 10;
    public float MaxForce = 15;
    public Vector3 velocity;

    public Node root;
    public Node healthCheck;
    public Node movementSelector;
    public Node attackSequence;

    void Start()
    {
        AddChildren();
    }

    void Update()
    {
        root.Execute(this);

        if (root.currentResult == Node.Result.failure)
        {
            AddChildren();
        }
    }

    void AddChildren()
    {
        root = new Selector();// First Selector
        Node healthCheck = new Selector();// Second Selector Left
        Node movementSelector = new Selector();// Third Selector
        Node attackSequence = new Sequencer();

        root.childrenNodes.Add(healthCheck);
        root.childrenNodes.Add(movementSelector);

        healthCheck.childrenNodes.Add(attackSequence);
        healthCheck.childrenNodes.Add(new Flee());
        healthCheck.childrenNodes.Add(new Die());

        attackSequence.childrenNodes.Add(new Chase());
        attackSequence.childrenNodes.Add(new Attack());

        movementSelector.childrenNodes.Add(new Patrol());
        movementSelector.childrenNodes.Add(new Wander());
    }
}
