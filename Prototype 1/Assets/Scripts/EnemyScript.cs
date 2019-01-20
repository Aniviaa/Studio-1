using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int enemyHealth;
    public int startHealth;
    public int enemyAttack;
    public bool inRange;
    public bool healthBarActive;
    ChasingBehavior CBScript;
    public bool dead;
    public bool weaponDropped;
    public bool ranged;
    public int weaponChosen;
    public GameObject[] weaponDrops;
    public GameObject droppedCoin;
    public GameObject enemyHealthSetup;
    public GameObject instantiatedenemyHealthSetup;
    public Vector3 coinMovement;

	void Start () 
    {
        CBScript = GetComponentInParent<ChasingBehavior>();
        startHealth = enemyHealth;
        healthBarActive = false;
	}
	
	void Update ()
    {
        if (startHealth != enemyHealth && !healthBarActive && transform.name != "Boss(Clone)")
        {
            instantiatedenemyHealthSetup = Instantiate(enemyHealthSetup, transform.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
            instantiatedenemyHealthSetup.transform.parent = this.transform;
            instantiatedenemyHealthSetup.transform.localScale /= 3;
            healthBarActive = true;
        }
        if (enemyHealth <= 0)
        {
            foreach (Collider collider in GetComponents<Collider>())
            {
                    collider.enabled = false;
            }

            Destroy(instantiatedenemyHealthSetup);
        }
        if (dead && !weaponDropped)
        {
            ChooseWeapon();
        }
	}

    void ChooseWeapon()
    {
        for (int i = 0; i < 3; i++)
        {
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
