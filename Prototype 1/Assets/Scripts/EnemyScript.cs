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
    public bool ranged;
    public int weaponChosen;
    public GameObject[] weaponDrops;
    public GameObject droppedCoin;
    public Vector3 coinMovement;

	void Start () 
    {
        CBScript = GetComponentInParent<ChasingBehavior>();
	}
	
	void Update ()
    {
        if (dead && !weaponDropped)
        {
            ChooseWeapon();
        }
	}

    void ChooseWeapon()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(weaponDropped);
            weaponChosen = Random.Range(0, 1);
            Vector3 enemyPosition = transform.position;
            droppedCoin = weaponDrops[weaponChosen];
            GameObject newCoin = Instantiate(droppedCoin, enemyPosition + new Vector3(0, 0.5f, 0), Quaternion.identity);
            coinMovement = (transform.up * 1f)+ (transform.forward * 1f) + (transform.right * Random.Range(-10, 10) * 0.5f);
            newCoin.GetComponent<Rigidbody>().AddForce(coinMovement, ForceMode.Impulse);
        }
        weaponDropped = true;
     
    }
}
