using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillImages : MonoBehaviour {

    public Image HealSkill;
    public Image SlowMoSkill;
    public Image AoESkill;
    public Text slowMoTime;
    public Text lifestealTime;


    PlayerController pcScript;

	// Use this for initialization
	void Start ()
    {
        pcScript = FindObjectOfType<PlayerController>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
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
