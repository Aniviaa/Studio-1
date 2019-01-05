using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator playerAnimator;

    public GameObject currentEnemy;
    public GameObject rangeCylinder;

    Rigidbody playerRigid;
    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRot;
    Vector3 whatever;
    float rotSpeed;
    public float speed;
    public bool moving;
    public bool grounded;
    public bool slowMo;
    public float attackTimer;
    public float slowMoTimer;
    public float slowMoSkillTimer;
    public float healSkillTimer;
    public float AoESkillTimer;
    public int playerHealth;
    public int playerAttack;
    public int healAmount;

	// Use this for initialization
	void Start ()
    {
        AoESkillTimer = 15;
        slowMoSkillTimer = 15;
        healSkillTimer = 15;
        slowMoTimer = 5;
        slowMo = false;
        playerHealth = 100;
        grounded = true;
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        playerRigid = GameObject.Find("Player").GetComponent<Rigidbody>();
        rotSpeed = 5;
        speed = 1;
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {

        attackTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log("Jump");
            playerRigid.AddForce(Vector3.up * 300);
            grounded = false;
        }

        if (Input.GetMouseButton(1))
        {
            SetTargetPosition();
            //Debug.Log("Clicked" + Distance());
            currentEnemy = null;
        }
        if (Input.GetMouseButton(0))
        {
            SetTargetEnemy();
        }
        if (moving)
        {
            Move();
            //Debug.Log(transform.position);
        }

        if (Distance() >= 10)
        {
            speed = 1.5f;
        }
        else
        {
            speed = 1;
        }
        SkillsCheck();
        Attack();
        ChangeCycle();

      }

    void SkillsCheck()
    {
        slowMoSkillTimer += Time.deltaTime;
        healSkillTimer += Time.deltaTime;
        AoESkillTimer += Time.deltaTime;

        if (slowMo)
        {
            slowMoSkillTimer = 0;
            slowMoTimer -= Time.deltaTime;

            if (slowMoTimer <= 0)
            {
                slowMo = false;
                slowMoTimer = 6;
            }
        }
    }

    void ChangeCycle()
    {
        if (speed >= 1.5 && moving)
        {
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Idle", false);
            playerAnimator.SetBool("Run", true);
            playerAnimator.SetBool("Attack", false);
        }
        else if(speed < 1.5 && moving)
        {
            playerAnimator.SetBool("Walk", true);
            playerAnimator.SetBool("Idle", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Attack", false);
        }
    }

    void SetTargetPosition()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000) && hit.transform.tag == "Ground")
        {

            targetPosition = hit.point;
            targetPosition.y = this.transform.position.y;
            lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
            moving = true;

            playerAnimator.SetBool("Walk", true);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Idle", false);
            playerAnimator.SetBool("Attack", false);

        }
    }

    void SetTargetEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                currentEnemy = hit.transform.gameObject;
            }
        }
    }

    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);


        if (transform.position == targetPosition)
        {
            moving = false;
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Idle", true);
            playerAnimator.SetBool("Attack", false);
        }
    }

    void Attack()
    {
        if (currentEnemy != null)
        {
            if (!currentEnemy.GetComponent<EnemyScript>().inRange)
            {
                transform.LookAt(currentEnemy.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, currentEnemy.transform.position, speed * Time.deltaTime);
            }
            else
            {


                if (attackTimer >= 3 && currentEnemy.GetComponent<EnemyScript>().inRange)
                {
                    attackTimer = 0;
                    currentEnemy.GetComponent<EnemyScript>().enemyHealth -= playerAttack;
                    this.transform.LookAt(currentEnemy.transform.position);
                    moving = false;
                    playerAnimator.SetBool("Walk", false);
                    playerAnimator.SetBool("Run", false);
                    playerAnimator.SetBool("Idle", false);
                    playerAnimator.SetBool("Attack", true);

                    //KnockBack(20);
                }


                if (Input.GetKeyDown(KeyCode.Q) && currentEnemy.GetComponent<EnemyScript>().inRange && healSkillTimer >= 15)
                {
                    healSkillTimer = 0;
                    if (playerHealth >= 100)
                    {
                        playerHealth = 100;
                    }
                    Debug.Log("Heal Skill");
                    currentEnemy.gameObject.GetComponent<EnemyScript>().enemyHealth -= healAmount;
                    playerHealth += healAmount;
                    KnockBack(300);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && slowMoTimer >= 0 && slowMoSkillTimer >= 15)
        {
            slowMo = true;
            Debug.Log("SuperSpeed");
        }
        if (Input.GetKeyDown(KeyCode.E) && AoESkillTimer >= 15)
        {
            AoESkillTimer = 0;
            Debug.Log("AOE");
            foreach (GameObject enemylist in rangeCylinder.gameObject.GetComponent<AoECheck>().enemyAOEList)
            {
                enemylist.gameObject.GetComponent<EnemyScript>().enemyHealth -= playerAttack;
                Vector3 pushDirection = enemylist.gameObject.transform.position - transform.position;
                pushDirection = pushDirection.normalized;
                enemylist.gameObject.GetComponent<Rigidbody>().AddForce(pushDirection * 500);

            }
            

        }
    }

    void KnockBack(float force)
    {
        Vector3 pushDirection = currentEnemy.transform.position - transform.position;
        pushDirection = pushDirection.normalized;
        currentEnemy.GetComponent<Rigidbody>().AddForce(pushDirection * force);
    }

    private float Distance()
    {
        return Vector3.Distance(targetPosition, transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}


