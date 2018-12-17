using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingBehavior : MonoBehaviour {

    GameObject player;
    public Animator enemyAnimator;
    public Transform[] patrolSpots;
    public int randomPatrolSpot;
    public float enemySpeed;
    public int minimumDistance;
    int maximumDistance;
    public bool dead;
    bool done;
    public bool enemyMoving;
    public bool lookAtTarget;
    public float idleTime;
    public float patrolTime;
    public float Mass = 15;
    public float MaxVelocity = 10;
    public float MaxForce = 15;
    private Vector3 velocity;
    
    void Start ()
    {
        idleTime = 3;
        done = true;
        dead = false;
        player = GameObject.Find("Player");

        enemySpeed = 10f;
        maximumDistance = 50;
	}
	

	void Update ()
    {
        if (GetComponent<EnemyScript>().enemyHealth >= 21)
        {
            EnemyWalkCycle();
        }

        if (GetComponent<EnemyScript>().enemyHealth <= 20 && !dead)
        {
            Flee();
        }

        if (GetComponent<EnemyScript>().enemyHealth <= 0)
        {
            dead = true;
            DieNow();
        }

        if (player.GetComponent<PlayerController>().slowMo)
        {
            enemySpeed = 4f;
        }
        else
        {
            enemySpeed = 6f;
        }


    }

    void DieNow()
    {
        if (done)
        {
            player.GetComponent<PlayerController>().currentEnemy = null;

            transform.LookAt(player.transform.position);
            done = false;
        }


        enemyAnimator.SetBool("Attack", false);
        enemyAnimator.SetBool("Idle", false);
        enemyAnimator.SetBool("Walk", false);
        enemyAnimator.SetBool("Dead", true);
    }

    public void EnemyPatrol()
    {
        lookAtTarget = true;
        if (lookAtTarget)
        {
            gameObject.transform.LookAt(patrolSpots[randomPatrolSpot].position);
        }
        enemyMoving = true;
        transform.position = Vector3.MoveTowards(transform.position, patrolSpots[randomPatrolSpot].position, enemySpeed * Time.deltaTime);
        //Quaternion.Slerp(transform.rotation, patrolSpots[randomPatrolSpot].rotation,0.5f);
        if (Vector3.Distance(transform.position, patrolSpots[randomPatrolSpot].position) <= 10)// This is so that when the enemy gets to the patrol spot, it stops even if it doesnt EXACTLY hit the 
        {
            enemyMoving = false;
            if (idleTime <= 0)
            {
                enemyMoving = true;
                lookAtTarget = true;
                randomPatrolSpot = Random.Range(0, patrolSpots.Length);
                idleTime = patrolTime;
            }

            else
            {
                enemyMoving = false;
                idleTime -= Time.deltaTime;
                lookAtTarget = false;
                enemyAnimator.SetBool("Attack", false);
                enemyAnimator.SetBool("Idle", true);
                enemyAnimator.SetBool("Walk", false);
                enemyAnimator.SetBool("Dead", false);
            }
        }
    }

    void EnemyWalkCycle()
    {

        if (!dead)
        {
            if (Vector3.Distance(transform.position, player.transform.position) >= maximumDistance)
            {
                //EnemyPatrol();
                enemyAnimator.SetBool("Attack", false);
                enemyAnimator.SetBool("Idle", false);
                enemyAnimator.SetBool("Walk", true);
                enemyAnimator.SetBool("Dead", false);
            }
            else if (Vector3.Distance(transform.position, player.transform.position) > minimumDistance)
            {
                transform.LookAt(player.transform);
                Vector3 enemyPosition = (player.gameObject.transform.position - transform.position).normalized;
                Vector3 Distance = new Vector3(enemyPosition.x, 0, enemyPosition.z);
                transform.position += Distance * enemySpeed * Time.deltaTime;

                enemyAnimator.SetBool("Attack", false);
                enemyAnimator.SetBool("Idle", false);
                enemyAnimator.SetBool("Walk", true);
                enemyAnimator.SetBool("Dead", false);

            }

            else if (Vector3.Distance(transform.position, player.transform.position) <= minimumDistance)
            {
                Debug.Log("Here now");
                enemyAnimator.SetBool("Attack", true);
                enemyAnimator.SetBool("Idle", false);
                enemyAnimator.SetBool("Walk", false);
                enemyAnimator.SetBool("Dead", false);
                player.GetComponent<PlayerController>().playerHealth -= GetComponent<EnemyScript>().enemyAttack;
            }
        }
    }

    void Flee()
    {
        enemyAnimator.SetBool("Attack", false);
        enemyAnimator.SetBool("Idle", false);
        enemyAnimator.SetBool("Walk", true);
        enemyAnimator.SetBool("Dead", false);
        var desiredVelocity = player.transform.position - transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity) / 2;
        if (player.GetComponent<PlayerController>().slowMo)
        {
            velocity = velocity / 2.5f;
        }
        transform.position -= velocity * Time.deltaTime;
        transform.forward = -velocity.normalized;


    }

    public void KnockBack()
    {

    }

}
