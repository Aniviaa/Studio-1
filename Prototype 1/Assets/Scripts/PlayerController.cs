using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public PlayerStatsTracker playerStatsScript;

    public Animator playerAnimator;

    public GameObject currentEnemy;
    public GameObject rangeCylinder;
    public GameObject stoneCenter;
    public string sceneName;
    public Scene currentScene;
    ShopPanel shopScript;
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
    public bool lifeSteal;
    public bool inStoneRange;
    public bool dead;
    public bool attackDone;
    public float attackTimer;
    public float slowMoTimer;
    public float slowMoSkillTimer;
    public float lifestealTimer;
    public float lifestealSkillTimer;
    public float healSkillTimer;
    public float AoESkillTimer;
    public float slashTimer;
    public float attackChoice;
    public float slashTimerSet;
    public int playerHealth;
    public int playerAttack;
    public int healAmount;
    public int coinsAmount;
    public float deathAssurance;
    AudioSource audioSource;
    public AudioClip[] audioClips;

    void Start ()
    {
        attackDone = true;
        playerStatsScript = FindObjectOfType<PlayerStatsTracker>();
        audioSource = GetComponent<AudioSource>();
        shopScript = FindObjectOfType<ShopPanel>();
        dead = false;
        coinsAmount = playerStatsScript.coinsCollected;
        slashTimer = 0;
        AoESkillTimer = 15;
        slowMoSkillTimer = 15;
        healSkillTimer = 15;
        lifestealSkillTimer = 15;
        slowMoTimer = 5;
        lifestealTimer = 11;
        slowMo = false;
        playerHealth = 100;
        grounded = true;
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        playerRigid = GameObject.Find("Player").GetComponent<Rigidbody>();
        rotSpeed = 5;
        speed = 1;
        moving = false;
        deathAssurance = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentEnemy)
        {

            Debug.Log(Vector3.Distance(transform.position, currentEnemy.transform.position));
        }
        playerHealth = playerStatsScript.playerHealth;

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (playerHealth >= 100)
        {
            playerHealth = 100;
        }
        if (playerHealth <= 0)
        {
            deathAssurance += Time.deltaTime;

            if (deathAssurance > .1f)
            {
                playerAnimator.SetBool("Dead", true);
                dead = true;
            }
        }

        healAmount = playerAttack;

        if (playerAttack != playerStatsScript.playerBasicDamage)
        {
            playerAttack = playerStatsScript.playerBasicDamage;
            Debug.Log("Playerattack != BasicDamage");
        }
        if (!playerStatsScript)
        {
            playerStatsScript = FindObjectOfType<PlayerStatsTracker>();
        }
        //playerStatsScript = FindObjectOfType<PlayerStatsTracker>();
        coinsAmount = playerStatsScript.coinsCollected;
        attackTimer += Time.deltaTime;
        slashTimer += Time.deltaTime;

        if (currentEnemy && slashTimer > 2)
        {
            playerAnimator.SetBool("Attack", false);
        }


            //-------------------------------------------------------------Easter--Egg---------------------------------------------------------------------------//
        if (Input.GetKey(KeyCode.Z))
        {
            SceneManager.LoadScene("Main Scene");
            Debug.Log("Load Scene");
        }
        if (Input.GetKey(KeyCode.X))
        {
            SceneManager.LoadScene("level 2");
            Debug.Log("Load Scene");
        }
        if (Input.GetKey(KeyCode.C))
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Load Scene");
        }

        //-------------------------------------------------------------Easter--Egg---------------------------------------------------------------------------//

        if (Input.GetMouseButton(1) && !dead)
        {

        }
        if (Input.GetMouseButton(0))
        {
            SetTargetEnemy();
            attackDone = false;

            if (currentEnemy && slashTimer > 0.4f && Vector3.Distance(transform.position, currentEnemy.transform.position) >= .4f)
            {
                    targetPosition = currentEnemy.transform.position;
                    targetPosition.y = this.transform.position.y;
                    lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
                    moving = true;
                    Debug.Log("ITS NOT TRUE");
                    Debug.Log(Vector3.Distance(transform.position, currentEnemy.transform.position));

            }
            SetTargetPosition();
        }
        if (moving)
        {
            Move();
        }

        if (Distance() >= 10)
        {
            speed = 2f;
        }
        else
        {
            speed = 1.5f;
        }
        SkillsCheck();
        Attack();
        ChangeCycle();

      }

    void SkillsCheck()
    {
        slowMoSkillTimer += Time.deltaTime;
        healSkillTimer += Time.deltaTime;
        lifestealSkillTimer += Time.deltaTime;
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
        if (lifeSteal)
        {
            lifestealSkillTimer = 0;
            lifestealTimer -= Time.deltaTime;

            if (lifestealTimer <= 0)
            {
                lifeSteal = false;
                lifestealTimer = 11;
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
        playerAnimator.SetBool("AOE", false);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000) && (hit.transform.tag == "Ground" || hit.transform.tag == "Enemy"))
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
            if (hit.transform.gameObject.tag == "Stone" && inStoneRange)
            {
                if (sceneName == "MainMenu")
                {
                    SceneManager.LoadScene("Main Scene");
                }
                else if (sceneName == "Main Scene")
                {
                    SceneManager.LoadScene("level 2");
                }
                
            }
        }
    }

    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);


        if (transform.position == targetPosition && !currentEnemy)
        {
            moving = false;
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Idle", true);
            playerAnimator.SetBool("Attack", false);
        }
    }

    void SingleAttack()
    {
        if (!currentEnemy.GetComponent<EnemyScript>().inRange)
        {
            transform.LookAt(currentEnemy.transform.position);
            //transform.position = Vector3.MoveTowards(transform.position, currentEnemy.transform.position, speed * Time.deltaTime);
            //KnockBack(100);
        }
        else
        {


            if (currentEnemy.GetComponent<EnemyScript>().inRange)
            {
                slashTimer = 0;
                if (lifeSteal)
                {
                    currentEnemy.gameObject.GetComponent<EnemyScript>().enemyHealth -= healAmount;
                    playerStatsScript.playerHealth += healAmount;
                }
                else
                {
                    currentEnemy.GetComponent<EnemyScript>().enemyHealth -= playerAttack;
                }

                this.transform.LookAt(currentEnemy.transform.position);
                moving = false;
                audioSource.Play();
                Debug.Log("Knocback");
                attackDone = true;
                if (currentEnemy.GetComponent<EnemyScript>().enemyHealth <= 11)
                {
                    KnockBack(50);
                }
                else
                {
                    KnockBack(200);
                }
            }
        }
    }

    void Attack()
    {
        if (currentEnemy != null)
        {
            if (!currentEnemy.GetComponent<EnemyScript>().inRange)
            {
                transform.LookAt(currentEnemy.transform.position);
                //transform.position = Vector3.MoveTowards(transform.position, currentEnemy.transform.position, speed * Time.deltaTime);
            }
            else
            {


                /** if (attackTimer >= 3 && currentEnemy.GetComponent<EnemyScript>().inRange)
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
                 }**/


            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && lifestealSkillTimer >= 15)
        {
            print(healSkillTimer);
            lifeSteal = true;
        }
        
        if (Input.GetKeyDown(KeyCode.W) && slowMoTimer >= 0 && slowMoSkillTimer >= 15)
        {
            slowMo = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && AoESkillTimer >= 15)
        {
            AoESkillTimer = 0;
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Idle", false);
            playerAnimator.SetBool("Attack", false);
            playerAnimator.SetBool("AOE", true);
        }
    }
    public void AoEAttack()
    {
        foreach (GameObject enemylist in rangeCylinder.gameObject.GetComponent<AoECheck>().enemyAOEList)
        {
            enemylist.gameObject.GetComponent<EnemyScript>().enemyHealth -= playerAttack;
            Vector3 pushDirection = enemylist.gameObject.transform.position - transform.position;
            pushDirection = pushDirection.normalized;
            enemylist.gameObject.GetComponent<Rigidbody>().AddForce(pushDirection * 250);
        }
        playerAnimator.SetBool("Walk", false);
        playerAnimator.SetBool("Run", false);
        playerAnimator.SetBool("Idle", true);
        playerAnimator.SetBool("Attack", false);
        playerAnimator.SetBool("AOE", false);
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

    public void Footsteps(int type)
    {
        if (type == 1)
        {
            audioSource.clip = audioClips[2];
        }
        else if (type == 2)
        {
            audioSource.clip = audioClips[3];
        }

        audioSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !attackDone && other.gameObject ==  currentEnemy 
            && Vector3.Distance(transform.position, currentEnemy.transform.position) <= .4f
            && slashTimer > slashTimerSet)
        {

            Debug.Log("This is true");
            moving = false;
            transform.LookAt(currentEnemy.transform.position);

            attackChoice = Random.Range(0, 10);

            if (attackChoice < 5)
            {
                audioSource.clip = audioClips[0];//JP DID THIS
            }
            if (attackChoice > 5)
            {
                audioSource.clip = audioClips[1];
            }

            transform.LookAt(currentEnemy.transform.position);
            attackChoice = Random.Range(0, 10);
            playerAnimator.SetInteger("AttackChoice", (int)attackChoice);

            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Idle", false);
            playerAnimator.SetBool("Attack", true);

            slashTimer = 0;
            attackDone = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && !attackDone && other.gameObject == currentEnemy 
            && Vector3.Distance(transform.position, currentEnemy.transform.position) <= .4f
            && slashTimer > slashTimerSet)
        {

            Debug.Log("This is true");
            moving = false;
            transform.LookAt(currentEnemy.transform.position);

            attackChoice = Random.Range(0, 10);

            if (attackChoice < 5)
            {
                audioSource.clip = audioClips[0];//JP DID THIS
            }
            if (attackChoice > 5)
            {
                audioSource.clip = audioClips[1];
            }

            transform.LookAt(currentEnemy.transform.position);
            attackChoice = Random.Range(0, 10);
            playerAnimator.SetInteger("AttackChoice", (int)attackChoice);

            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Idle", false);
            playerAnimator.SetBool("Attack", true);

            slashTimer = 0;
            attackDone = true;
        }
    }

}


