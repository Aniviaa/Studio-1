﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    public GameObject player;
    public int arrowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerAttackPosition");
        transform.LookAt(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = (player.gameObject.transform.position - transform.position).normalized;
        Vector3 Distance = new Vector3(playerPosition.x, 0, playerPosition.z);
<<<<<<< HEAD
        transform.position += Distance * arrowSpeed * Time.deltaTime;
=======
        transform.position += Distance * 100 * Time.deltaTime;
>>>>>>> cd38dabad7874f9ef5ad44619985150fb2ac18c6
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("False");
            gameObject.SetActive(false);

        }
    }
}
