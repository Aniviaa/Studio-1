using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoECheck : MonoBehaviour {
    
    public List<GameObject> enemyAOEList = new List<GameObject>();



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyScript>().inRange = true;
            enemyAOEList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyScript>().inRange = false;
            enemyAOEList.Remove(other.gameObject);
        }
    }
}
