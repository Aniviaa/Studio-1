using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSpawner : MonoBehaviour
{

    public int timer;
    public int totalSpawnBossPoints;
    public int requiredSpawnBossPoints;
    public GameObject bossSpawnLocation;
    public GameObject boss;
    public GameObject[] enemies;
    public bool bossSpawned;

    public PlayerStatsTracker playerStats;
    public Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStatsTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        totalSpawnBossPoints = playerStats.enemiesKilled;

        SpawnBoss();
    }

    public void SpawnBoss()
    {
        if(totalSpawnBossPoints >= requiredSpawnBossPoints)
        {
            KillAllEnemies();
            if (!bossSpawned && currentScene.name == "level 2")
            {
                Instantiate(boss, bossSpawnLocation.transform.position, bossSpawnLocation.transform.rotation);
                totalSpawnBossPoints = 0;
                bossSpawned = true;
            }
        }
    }

    public void KillAllEnemies()
    {
       enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach(GameObject enemy in enemies)
        {
            if (enemy.name != "Boss(Clone)")
            {
                enemy.GetComponent<EnemyScript>().enemyHealth = 0;
            }
        }
    }
}
