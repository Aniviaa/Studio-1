using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public GameObject player;  //The offset of the camera to centrate the player in the X axis
    public float offsetx = 0;  //The offset of the camera to centrate the player in the Z axis
    public float offsetz = 0;  //The maximum distance permited to the camera to be far from the player, its used to     make a smooth movement
    public float maximumdistance = 2;  //The velocity of your player, used to determine que speed of the camera
    public float playervelocity;
    public float yRotation;
    public float cameraYRotation;
    private float movementx;
    private float movementz;
    public bool minus;
    public bool zMinus;

    // Update is called once per frame
    private void Start()
    {
        zMinus = true;
        this.transform.LookAt(player.transform.position);
        player = GameObject.Find("Player");
    }

    void Update()
    {
        this.transform.LookAt(player.transform.position);
        yRotation = player.transform.eulerAngles.y;
        if (yRotation >= 180 && minus)
        {
            offsetx = -offsetx;
            Debug.Log("MINUS");
            minus = false;
        }
        if (yRotation <= 179)
        {
           minus = true;
        }
        playervelocity = player.GetComponent<PlayerController>().speed;
        movementx = ((player.transform.position.x + offsetx - this.transform.position.x)) / maximumdistance;
        movementz = ((player.transform.position.z + offsetz - this.transform.position.z)) / maximumdistance;
        this.transform.position += new Vector3((movementx * Time.deltaTime), 0, (movementz * Time.deltaTime));

        if (Vector3.Distance(player.transform.position, transform.position) <= 1.7 && zMinus)
        {
            zMinus = false;

            offsetz = -offsetz;
        }
        if (Vector3.Distance(player.transform.position, transform.position) >= 2 && !zMinus)
        {
            zMinus = true;
        }

    }
}


