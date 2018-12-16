using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Node
{

    public override void Execute(EnemyBehaviorTree EBT)
    {

        if (Vector3.Distance(EBT.transform.position, EBT.player.transform.position) >= EBT.maximumDistance || EBT.GetComponent<EnemyScript>().enemyHealth < 30) // Checking if its too far
        {
            currentResult = Result.failure;
            Debug.Log("Chase Failed");
        }

        else if (Vector3.Distance(EBT.transform.position, EBT.player.transform.position) > EBT.minimumDistance)// Checking if close
        {
            EBT.transform.LookAt(EBT.player.transform);
            Vector3 enemyPosition = (EBT.player.gameObject.transform.position - EBT.transform.position).normalized;
            Vector3 Distance = new Vector3(enemyPosition.x, 0, enemyPosition.z);
            EBT.transform.position += Distance * EBT.enemySpeed * Time.deltaTime;

            EBT.enemyAnimator.SetBool("Attack", false);
            EBT.enemyAnimator.SetBool("Idle", false);
            EBT.enemyAnimator.SetBool("Walk", true);
            EBT.enemyAnimator.SetBool("Dead", false);

            currentResult = Result.running;

            Debug.Log("Chase");

        }

        else if (Vector3.Distance(EBT.transform.position, EBT.player.transform.position) <= EBT.minimumDistance)// Checking if right next to him
        {
            currentResult = Result.success;
            Debug.Log("Chase Sucess");
        }



    }
}
