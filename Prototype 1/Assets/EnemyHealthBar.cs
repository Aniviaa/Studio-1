using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    public EnemyScript enemyScript;

    public float enemyHealth;

    public Image enemyHealthBar;

    public GameObject cameraMain;
    // Start is called before the first frame update
    void Start()
    {
        cameraMain = GameObject.Find("Main Camera");
        enemyScript = GetComponentInParent<EnemyScript>();
        enemyHealth = enemyScript.startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthBar.fillAmount = enemyScript.enemyHealth / enemyHealth;
        transform.LookAt(cameraMain.transform.position);
    }
}
