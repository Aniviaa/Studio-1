using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {


    public GameObject player;  //The offset of the camera to centrate the player in the X axis
    public float offsetX = 0;  //The offset of the camera to centrate the player in the Z axis
    public float offsetZ = 0;  //The maximum distance permited to the camera to be far from the player, its used to     make a smooth movement
    public float maximumDistance = 2;  //The velocity of your player, used to determine que speed of the camera
    public float playerVelocity;

    private float movementX;
    private float movementZ;

    // Update is called once per frame
    private void Start()
    {
        this.transform.LookAt(player.transform.position);
    }

    void Update()
    {
        playerVelocity = player.GetComponent<PlayerController>().speed;
        movementX = ((player.transform.position.x + offsetX - this.transform.position.x)) / maximumDistance;
        movementZ = ((player.transform.position.z + offsetZ - this.transform.position.z)) / maximumDistance;
        this.transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), 0, (movementZ * playerVelocity * Time.deltaTime));

        if (player.GetComponent<PlayerController>().moving)
        {
            this.transform.LookAt(player.transform.position);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles -= new Vector3(0, 1, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += new Vector3(0, 1, 0);
        }
    }
}


