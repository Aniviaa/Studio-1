using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    public int roomKind;

    public RoomsArrays rooms;
    public int randomRoom;
    public bool spawned;
    public float time = 5f;
    public int limitStartingRooms;
    public int maxLimiter;

    private void Update()
    {
        if (rooms.startTime > 0 || rooms.roomAmount.Count <= 20)
        {
            limitStartingRooms = 2;
            maxLimiter = 1;
        }
        else
        {
            limitStartingRooms = 0;
            maxLimiter = 0;
        }
    }
    private void Start()
    {
        
        Destroy(gameObject, time);
        rooms = FindObjectOfType<RoomsArrays>();

        Invoke("SpawnRoom", 0.1f);
    }
    void SpawnRoom ()
    {
        if (!spawned)
        {
            if (roomKind == 1)
            {
                randomRoom = Random.Range(limitStartingRooms, rooms.roomsKindRight.Length);
                Instantiate(rooms.roomsKindRight[randomRoom * maxLimiter], transform.position, rooms.roomsKindRight[randomRoom].transform.rotation);
            }
            else if (roomKind == 2)
            {
                randomRoom = Random.Range(limitStartingRooms, rooms.roomsKindBottom.Length);
                Instantiate(rooms.roomsKindBottom[randomRoom * maxLimiter], transform.position, rooms.roomsKindBottom[randomRoom].transform.rotation);
            }
            else if (roomKind == 3)
            {
                randomRoom = Random.Range(limitStartingRooms, rooms.roomsKindTop.Length);
                Instantiate(rooms.roomsKindTop[randomRoom * maxLimiter], transform.position, rooms.roomsKindTop[randomRoom].transform.rotation);
            }
            else if (roomKind == 4)
            {
                randomRoom = Random.Range(limitStartingRooms, rooms.roomsKindLeft.Length);
                Instantiate(rooms.roomsKindLeft[randomRoom * maxLimiter], transform.position, rooms.roomsKindLeft[randomRoom].transform.rotation);
            }
            spawned = true;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("SpawnPoints"))
        {
                if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false && other.gameObject != null)
                {
                    Instantiate(rooms.Block, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                spawned = true;
            
        }
    }
}
