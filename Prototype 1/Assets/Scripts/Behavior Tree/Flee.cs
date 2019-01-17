using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : Node
{

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (EBT.GetComponent<EnemyScript>().enemyHealth <= 10 && EBT.GetComponent<EnemyScript>().enemyHealth > 0)
        {
            EBT.enemyAnimator.SetBool("Attack", false);
            EBT.enemyAnimator.SetBool("Idle", false);
            EBT.enemyAnimator.SetBool("Walk", true);
            EBT.enemyAnimator.SetBool("Dead", false);

            var desiredVelocity = EBT.player.transform.position - EBT.transform.position;
            desiredVelocity = desiredVelocity.normalized * EBT.MaxVelocity;

            var steering = desiredVelocity - EBT.velocity;
            steering = Vector3.ClampMagnitude(steering, EBT.MaxForce);
            steering /= EBT.Mass;

            EBT.velocity = Vector3.ClampMagnitude(EBT.velocity + steering, EBT.MaxVelocity) / 3;
            if (EBT.player.GetComponent<PlayerController>().slowMo)
            {
                EBT.velocity = EBT.velocity / 2.5f;
            }
            EBT.transform.position -= EBT.velocity * Time.deltaTime;
            EBT.transform.forward = -EBT.velocity.normalized;

            return Result.success;
        }

        else
        {
            return Result.failure;
        }
    }
}