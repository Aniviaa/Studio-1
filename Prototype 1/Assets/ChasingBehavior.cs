using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingBehavior : MonoBehaviour {

    GameObject player;

    float enemySpeed;
    public int minimumDistance;
    int maximumDistance;


    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");

        enemySpeed = 15f;
        maximumDistance = 50;
	}
	
	// Update is called once per frame
	void Update ()
    {
        EnemyWalkCycle();

    }

    void EnemyWalkCycle()
    {
        

            transform.LookAt(player.transform);
            if (Vector3.Distance(transform.position, player.transform.position) >= minimumDistance)
            {
                Vector3 enemyPosition = (player.gameObject.transform.position - transform.position).normalized;
                Vector3 Distance = new Vector3(enemyPosition.x, 0, enemyPosition.z);
                transform.position += Distance * enemySpeed * Time.deltaTime;





                if (Vector3.Distance(transform.position, player.transform.position) <= maximumDistance)
                {

                }
            }
        
    }
}
