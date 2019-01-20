using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDistancePlayerStone : MonoBehaviour
{
    public PlayerController playerScript;
    public GameObject player;
    public float minDistance;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerController>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= minDistance)
        {
            playerScript.inStoneRange = true;
        }
        else
        {
            playerScript.inStoneRange = false;
        }
    }
}
