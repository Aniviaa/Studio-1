using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardsTraining : MonoBehaviour
{
    public Animator anim;
    public GameObject otherGuard;
    public int attackType;
    public float attackTime;
    
    // Start is called before the first frame update
    void Start()
    {
        attackTime = 0;
        anim = GetComponentInParent<Animator>();
        anim.SetInteger("AttackType", attackType);
    }

    // Update is called once per frame
    void Update()
    {
        attackTime += Time.deltaTime;

        if (attackTime >= 1f)
        {
            if (attackType == 1)
            {
                attackType = 0;
                anim.SetInteger("AttackType", attackType);
            }
            else if (attackType == 0)
            {
                attackType = 1;
                anim.SetInteger("AttackType", attackType);
            }
            attackTime = 0;
        }


    }
}
