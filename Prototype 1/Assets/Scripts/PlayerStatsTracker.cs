using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsTracker : MonoBehaviour
{

    public PlayerController playerScript;
    public int coinsCollected;
    public int damageModifier;
    public int playerBasicDamage;
    public int upgradeCost;
    public int upgradeDamage;
    public bool attackIncreased;
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
        playerBasicDamage = 10;
        damageModifier = 5;
        upgradeCost = 1000;
        upgradeDamage = 10;
        playerScript = FindObjectOfType<PlayerController>();
    }

    public void Update()
    {

    }

}
