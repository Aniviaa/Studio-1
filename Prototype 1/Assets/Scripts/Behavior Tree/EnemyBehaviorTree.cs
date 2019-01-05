using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorTree : MonoBehaviour{

    public GameObject player;
    public GameObject arrow;
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
    public Node attackSelector;
    public Node attackSequence;

    void Start()
    {
        AddChildren();
    }

    void Update()
    {
        root.Execute(this);
    }
    /// <summary>
    /// Remember to look up Delegates and use them for functions.
    /// </summary>
    void AddChildren()
    {
        root = new Selector();// First Selector
        Node healthCheck = new Selector();// Second Selector Left
        Node movementSelector = new Selector();// Third Selector
        Node attackSelector = new Selector();
        Node attackSequence = new Sequencer();//Melee Enemy Sequencer

        root.childrenNodes.Add(healthCheck);
        root.childrenNodes.Add(movementSelector);

        healthCheck.childrenNodes.Add(attackSequence);
        healthCheck.childrenNodes.Add(new Flee());
        healthCheck.childrenNodes.Add(new Die());

        attackSequence.childrenNodes.Add(new Chase());
        attackSequence.childrenNodes.Add(attackSelector);

        attackSelector.childrenNodes.Add(new Attack());
        attackSelector.childrenNodes.Add(new RangedAttack());

        movementSelector.childrenNodes.Add(new Patrol());
        movementSelector.childrenNodes.Add(new Wander());
    }

    public bool CheckingDistanceMinimum()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= minimumDistance)
        {
            return true;
        }
        return false;
    }

    public bool CheckingDistanceMaximum()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= maximumDistance)
        {
            return true;
        }
        return false;
    }
}