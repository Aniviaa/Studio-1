using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public PlayerController playerScript;
    public int coinValue;

    void Start()
    {
        playerScript = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerScript.coinsAmount += coinValue;
            Debug.Log("Coin Collected: " + coinValue);
            Destroy(gameObject);
        }
        
    }


}
