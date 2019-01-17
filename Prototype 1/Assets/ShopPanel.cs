using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject weaponPanel;
    public GameObject lifestealPanel;
    public GameObject slowmoPanel;
    public GameObject aoePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableShopPanel()
    {
        shopPanel.SetActive(true);
        weaponPanel.SetActive(false);
        lifestealPanel.SetActive(false);
        slowmoPanel.SetActive(false);
        aoePanel.SetActive(false);
    }

    public void EnableWeaponPanel()
    {
        weaponPanel.SetActive(true);
    }

    public void EnableLifestealPanel()
    {
        lifestealPanel.SetActive(true);
    }

    public void EnableSlowMoPanel()
    {
        slowmoPanel.SetActive(true);
    }

    public void EnableAoEPanel()
    {
        aoePanel.SetActive(true);
    }
}
