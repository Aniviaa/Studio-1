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
    public Image gameoverImage;

    public Text slowMoTime;
    public Text lifestealTime;
    public Text aoeTime;
    public Text time;
    public Text enemiesKilled;

    public float lifestealCD;
    public float slowmoCD;
    public float aoeCD;

    public float deathTimer;
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
        lifestealCD = 25;
        slowmoCD = 20;
        aoeCD = 15;
        aoeTime.enabled = false;
        lifestealTime.enabled = false;
        gameoverImage.GetComponent<Animator>().enabled = false;
        gameoverImage.enabled = false;
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

        if (pcScript.playerHealth <= 0)
        {
            deathTimer += Time.deltaTime;

            if (deathTimer >= 2)
            {
                GameOver();
            }
        }
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

        lifestealTime.text = "" + (int)lifestealCD;
        slowMoTime.text = "" + (int)slowmoCD;
        aoeTime.text = "" + (int)aoeCD;
        updateSkills();

    }

    public void updateSkills()
    {
        float healRatio = pcScript.lifestealSkillTimer;
        float slowMoRatio = pcScript.slowMoSkillTimer;
        float aoeRatio = pcScript.AoESkillTimer;
        Debug.Log(pcScript.lifestealSkillTimer);


        

        slowMoTime.enabled = pcScript.slowMo;
        if (pcScript.lifestealSkillTimer < 15)
        {
            lifestealTime.enabled = true;
            lifestealCD -= Time.deltaTime;
        }
        else if(lifestealCD <= 0)
        {
            lifestealTime.enabled = false;
            lifestealCD = 25;
        }
        if (pcScript.slowMoSkillTimer < 15)
        {
            slowMoTime.enabled = true;
            slowmoCD -= Time.deltaTime;
        }
        else if (slowmoCD <= 0)
        {
            slowMoTime.enabled = false;
            slowmoCD = 20;
        }
        if (pcScript.AoESkillTimer < 15)
        {
            aoeTime.enabled = true;
            aoeCD -= Time.deltaTime;
        }
        else if (aoeCD <= 0)
        {
            aoeTime.enabled = false;
            aoeCD = 15;
        }



        HealSkill.fillAmount = healRatio / 15;
        SlowMoSkill.fillAmount = slowMoRatio / 15;
        AoESkill.fillAmount = aoeRatio / 15;
    }

    public void GameOver()
    {
        gameoverImage.GetComponent<Animator>().enabled = true;
        gameoverImage.enabled = true;
        Debug.Log("Death true");
    }
}
