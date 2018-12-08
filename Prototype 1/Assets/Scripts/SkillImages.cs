using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillImages : MonoBehaviour {

    public Image HealSkill;
    public Image SlowMoSkill;
    public Image AoESkill;
    public Text slowMoTime;

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
        float healRatio = pcScript.healSkillTimer;
        float slowMoRatio = pcScript.slowMoSkillTimer;
        float aoeRatio = pcScript.AoESkillTimer;
        if (pcScript.slowMo)
        {
            slowMoTime.enabled = true;
        }
        else
        {
            slowMoTime.enabled = false;
        }
        slowMoTime.text = ""+(int)pcScript.slowMoTimer;
        HealSkill.fillAmount = healRatio / 15;
        SlowMoSkill.fillAmount = slowMoRatio / 15;
        AoESkill.fillAmount = aoeRatio / 15;
    }
}
