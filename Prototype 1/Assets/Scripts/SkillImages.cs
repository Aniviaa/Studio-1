using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillImages : MonoBehaviour {

    public Image HealSkill;
    public Image SlowMoSkill;
    public Image AoESkill;
    public Image healthBar;

    public Text slowMoTime;
    public Text lifestealTime;
    public Text time;

    public float timeMin;
    public float timeSec;

    public float playerHealth;

    PlayerController pcScript;
    PlayerStatsTracker statsScript;

	// Use this for initialization
	void Start ()
    {
        playerHealth = 100;
        pcScript = FindObjectOfType<PlayerController>();
        statsScript = FindObjectOfType<PlayerStatsTracker>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeMin = (int)statsScript.gameTimer / 60;
        timeSec = (int)statsScript.gameTimer % 60;

        time.text = timeMin.ToString() + " : " + timeSec.ToString();

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
