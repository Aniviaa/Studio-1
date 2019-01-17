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


 
    void Start()
    {
        
    }

    void Update()
    {
        
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
