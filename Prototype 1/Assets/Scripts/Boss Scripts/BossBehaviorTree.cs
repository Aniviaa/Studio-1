using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviorTree : MonoBehaviour
{

    public GameObject player;
    public float minimumDistance;
    public float maximumDistance;
    public float attackTime;
    public float enemySpeed;
    public int attackType;
    public int attackRange;
    public int mana = 100;
    public bool moving;

    public BossNode root;
    public BossNode meleeRanged;
    public BossNode healthCheck;
    //public BossNode manaCheck;
    public BossNode attackSequence;

    public Animator anim;
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        AddChildren();
    }

    // Update is called once per frame
    void Update()
    {
        attackType = attackRange = Random.Range(0, 10);
        attackTime += Time.deltaTime;
        if (!player)
        {
            player = GameObject.Find("Player");
        }
        root.Execute(this);
        anim.SetInteger("AttackType", attackType);
    }

    public void AddChildren()
    {
        root = new BossSelector(); // First Node -> Selector
        healthCheck = new BossSelector(); // Second Node - Selector
        attackSequence = new BossSequencer(); // First Sequencer
        meleeRanged = new BossSelector(); // Third Node -> Selector


        root.childrenNodes.Add(healthCheck);
        healthCheck.childrenNodes.Add(attackSequence);
        healthCheck.childrenNodes.Add(new BossDie());
        //attackSequence.childrenNodes.Add()
        //make it a sequence under the healthcheck

        //attackSequence.childrenNodes.Add(new BossManaCheck());
        attackSequence.childrenNodes.Add(new BossChase());
        attackSequence.childrenNodes.Add(meleeRanged);

        

        meleeRanged.childrenNodes.Add(new BossRangedAttack());
        meleeRanged.childrenNodes.Add(new BossMeleeAttack());

        root.childrenNodes.Add(new BossIdle());
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
