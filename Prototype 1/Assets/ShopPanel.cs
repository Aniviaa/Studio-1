using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public GameObject shopPanel;
    public Text upgradeCost;
    public Text weaponDamage;
    public Text weaponFutureDamage;
    PlayerStatsTracker statsScript;

 
    void Start()
    {
        statsScript = FindObjectOfType<PlayerStatsTracker>();
    }

    void Update()
    {
        upgradeCost.text = statsScript.upgradeCost.ToString();
        weaponFutureDamage.text = statsScript.upgradeDamage.ToString();
    }

    public void DisableShopPanel()
    {
        shopPanel.SetActive(false);
    }
    public void EnableShopPanel()
    {
        shopPanel.SetActive(true);
    }
}
