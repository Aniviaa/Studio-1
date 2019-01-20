using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillImages : MonoBehaviour {

    public Image HealSkill;
    public Image SlowMoSkill;
    public Image AoESkill;
    public Image healthBar;
    public Image enemiesBar;
    public Image enemiesBackBar;
    public Image bossHealthBar;

    public Text slowMoTime;
    public Text lifestealTime;
    public Text time;
    public Text enemiesKilled;

    public float timeMin;
    public float timeSec;
    public float playerHealth;
    public float bossHealth;
    public float enemiesKilledNumber;
    public float enemiesNeeded;
    public GameObject boss;
    public GameObject bossHealthSetup;
    PlayerController pcScript;
    PlayerStatsTracker statsScript;
    BossSpawner bossScript;

	// Use this for initialization
	void Start ()
    {
        enemiesBar.fillAmount = 0;
        playerHealth = 100;
        pcScript = FindObjectOfType<PlayerController>();
        statsScript = FindObjectOfType<PlayerStatsTracker>();
        bossScript = FindObjectOfType<BossSpawner>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeMin = (int)statsScript.gameTimer / 60;
        timeSec = (int)statsScript.gameTimer % 60;
        enemiesKilledNumber = statsScript.enemiesKilled;
        enemiesNeeded = bossScript.requiredSpawnBossPoints;


        if (!bossScript.bossSpawned)
        {
            time.text = timeMin.ToString("00") + " : " + timeSec.ToString("00");
            enemiesKilled.text = enemiesKilledNumber.ToString() + "/" + enemiesNeeded.ToString();
            enemiesBar.fillAmount = enemiesKilledNumber / enemiesNeeded;
        }
        else
        {
            boss = GameObject.Find("Boss(Clone)");
            bossHealthSetup.SetActive(true);
            bossHealthBar.gameObject.SetActive(true);
            bossHealthBar.fillAmount = boss.GetComponent<EnemyScript>().enemyHealth / bossHealth;
            time.gameObject.SetActive(false);
            enemiesKilled.gameObject.SetActive(false);
            enemiesBar.gameObject.SetActive(false);
            enemiesBackBar.gameObject.SetActive(false);
        }

        healthBar.fillAmount = pcScript.playerHealth / playerHealth;
        updateSkills();
    }

    public void updateSkills()
    {
        float healRatio = pcScript.lifestealSkillTimer;
        float slowMoRatio = pcScript.slowMoSkillTimer;
        float aoeRatio = pcScript.AoESkillTimer;

        slowMoTime.enabled = pcScript.slowMo;
        lifestealTime.enabled = pcScript.lifeSteal;

        slowMoTime.text = "" + (int)pcScript.slowMoTimer;
        lifestealTime.text = "" + (int)pcScript.lifestealTimer;
        HealSkill.fillAmount = healRatio / 15;
        SlowMoSkill.fillAmount = slowMoRatio / 15;
        AoESkill.fillAmount = aoeRatio / 15;
    }
}
