using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform player;
    public Vector3 offset;


    
    void Update()
    {
        transform.position = player.position + offset;
        transform.rotation = player.transform.rotation;
    }
}


