using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    public GameObject player;
    public Vector3 playerPosition;
    public Vector3 Distance;
    public float arrowInActive;
    public int arrowSpeed;

    void Start()
    {
        player = GameObject.Find("PlayerAttackPosition");
        transform.LookAt(player.transform.position);

        playerPosition = (player.gameObject.transform.position - transform.position).normalized;
        Distance = new Vector3(playerPosition.x, 0, playerPosition.z);
        transform.LookAt(player.transform.position);

        arrowInActive = 0;
    }

    void Update()
    {
        arrowInActive += Time.deltaTime;
        transform.position += Distance * 1 * Time.deltaTime;

        if (arrowInActive >= 2)
        {
            arrowInActive = 0;
            gameObject.SetActive(false);
        }

        playerPosition = (player.gameObject.transform.position - transform.position).normalized;
        Distance = new Vector3(playerPosition.x, 0, playerPosition.z);
        transform.position += Distance * 1 * Time.deltaTime;
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
