using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatsTracker : MonoBehaviour
{

    public PlayerController playerScript;

    public float gameTimer;//if timer runs out before enemies required are killed he goes back to main menu and enemies killed goes back to zero
    public int playerHealth;
    public int coinsCollected;
    public int damageModifier;
    public int playerBasicDamage;
    public int upgradeCost;
    public int upgradeDamage;
    public int enemiesKilled;
    public bool attackIncreased;

    public BossSpawner bossSpawner;
    private static PlayerStatsTracker instance = null;

    public static PlayerStatsTracker Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }

    }

    public void Start()
    {
        playerHealth = 100;
        playerBasicDamage = 10;
        damageModifier = 5;
        upgradeCost = 1000;
        upgradeDamage = 10;
        playerScript = FindObjectOfType<PlayerController>();
        bossSpawner = FindObjectOfType<BossSpawner>();
    }

    public void Update()
    {
        //playerHealth = playerScript.playerHealth;

        if (playerHealth >= 100)
        {
            playerHealth = 100;
        }
        gameTimer -= Time.deltaTime;

        if (gameTimer <= 0 && enemiesKilled <= bossSpawner.requiredSpawnBossPoints)
        {
            enemiesKilled = 0;
            SceneManager.LoadScene("MainMenu");
        }
    }

}
