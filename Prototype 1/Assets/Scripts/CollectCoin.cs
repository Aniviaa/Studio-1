using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public PlayerStatsTracker playerScript;
    public int coinValue;

    void Start()
    {
        playerScript = FindObjectOfType<PlayerStatsTracker>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerScript.coinsCollected += coinValue;
            Debug.Log("Coin Collected: " + coinValue);
            Destroy(gameObject);
        }
        
    }


}
