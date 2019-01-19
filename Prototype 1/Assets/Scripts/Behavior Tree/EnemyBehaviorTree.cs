using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorTree : MonoBehaviour{

    public GameObject player;
    public GameObject arrow;
    public GameObject arrowPositions;
    public Animator enemyAnimator;
    public Transform[] patrolSpots;
    public int randomPatrolSpot;
    public float enemySpeed;
    public float minimumDistance;
    public int maximumDistance;
    public bool dead;
    public bool done;
    public bool enemyMoving;
    public bool lookAtTarget;
    public float idleTime;
    public float patrolTime;
    public float attackTime;
    public float Mass = 15;
    public float MaxVelocity = 10;
    public float MaxForce = 15;
    public Vector3 velocity;

    public Node root;
    public Node healthCheck;
    public Node movementSelector;
    public Node attackSelector;
    public Node attackSequence;

    public EnemyScript enemyScript;
    public ObjectPool objectPool;
    public PlayerStatsTracker playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStatsTracker>();
        enemyScript = GetComponentInParent<EnemyScript>();
        objectPool = FindObjectOfType<ObjectPool>();
        AddChildren();
        player = GameObject.Find("Player");
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

    public void KnockBack(float force)
    {
        Vector3 pushDirection = player.transform.position - transform.position;
        pushDirection = pushDirection.normalized;
        player.GetComponent<Rigidbody>().AddForce(pushDirection * force);
    }
}