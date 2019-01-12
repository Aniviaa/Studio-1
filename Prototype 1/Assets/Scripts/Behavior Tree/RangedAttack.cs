using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : Node
{
    public override Result Execute(EnemyBehaviorTree EBT)
    {
<<<<<<< HEAD
        if (Vector3.Distance(EBT.transform.position, EBT.player.transform.position) <= EBT.minimumDistance)
=======
        if (Vector3.Distance(EBT.transform.position, EBT.player.transform.position) <= EBT.minimumDistance
            && EBT.GetComponent<EnemyScript>().enemyHealth > 0 &&
            EBT.GetComponent<EnemyScript>().ranged
            && EBT.attackTime > 30)
>>>>>>> 30d5fdd018b2daec6428a747ad1467755e5e3486
        {
            EBT.enemyAnimator.SetBool("Attack", true);
            EBT.enemyAnimator.SetBool("Idle", false);
            EBT.enemyAnimator.SetBool("Walk", false);
            EBT.enemyAnimator.SetBool("Dead", false);
            EBT.player.GetComponent<PlayerController>().playerHealth -= EBT.GetComponent<EnemyScript>().enemyAttack;
<<<<<<< HEAD

            Instantiate(EBT.arrow, EBT.transform.position, Quaternion.identity);
            return Result.success;
        }
        else return Result.failure;
    }

   
=======
            Instantiate(EBT.arrow, EBT.arrowPositions.transform.position, Quaternion.identity);
            EBT.attackTime = 0;
            return Result.success;
        }
        else
            EBT.attackTime += Time.deltaTime;
        return Result.failure;
    }
>>>>>>> 30d5fdd018b2daec6428a747ad1467755e5e3486
}
