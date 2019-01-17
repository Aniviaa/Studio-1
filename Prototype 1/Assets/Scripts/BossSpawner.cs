using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{

    public int timer;
    public int totalSpawnBossPoints;
    public int requiredSpawnBossPoints;
    public GameObject bossSpawnLocation;
    public GameObject boss;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBoss();
    }

    public void SpawnBoss()
    {
        if(totalSpawnBossPoints >= requiredSpawnBossPoints)
        {
            KillAllEnemies();
            Instantiate(boss, bossSpawnLocation.transform.position, Quaternion.identity);
            totalSpawnBossPoints = 0;
            Debug.Log("Boss Spawned");
        }
    }

    public void KillAllEnemies()
    {
       enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyScript>().enemyHealth = 0;
        }
    }
}
