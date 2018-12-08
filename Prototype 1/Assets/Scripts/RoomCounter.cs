using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCounter : MonoBehaviour
{

    public RoomsArrays rooms;


    void Start()
    {
        rooms = FindObjectOfType<RoomsArrays>();
        rooms.roomAmount.Add(this.gameObject);
    }
}
