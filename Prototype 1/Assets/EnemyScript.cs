using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {


    public int enemyHealth;
    public int enemyAttack;
    public bool inRange;

    ChasingBehavior CBScript;
    public bool dead;
    public bool weaponDropped;
    public int weaponChosen;
    public GameObject[] weaponDrops;

	void Start () 
    {
        CBScript = GetComponentInParent<ChasingBehavior>();
	}
	
	void Update ()
    {
        dead = CBScript.dead;

        if (dead && !weaponDropped)
        {
            ChooseWeapon();
        }
	}

    void ChooseWeapon()
    {
        weaponChosen = Random.Range(0, 3);
        Vector3 enemyPosition = transform.position;
        Instantiate(weaponDrops[weaponChosen], enemyPosition, Quaternion.identity);
        weaponDropped = true;
    }


}
