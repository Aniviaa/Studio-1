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
    public enum directions { idle, mad, chase, die};
    public directions currentstate;

    private void Update()
    {
        if (currentstate == directions.chase)
        {
            //DO WHATEVER IS NEEDED FOR CHASE, DONT WORRY ABOUT THIS, THIS IS JUST AN EXAMPLE.
        }
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
                Instantiate(rooms.halls[0], transform.position, this.transform.rotation);
            }
            else if (roomKind == 2)
            {
                Instantiate(rooms.halls[1], transform.position, this.transform.rotation);
            }
            else if (roomKind == 3)
            {
                Instantiate(rooms.halls[2], transform.position, this.transform.rotation);
            }
            else if (roomKind == 4)
            {
                Instantiate(rooms.halls[3], transform.position, this.transform.rotation);
            }
            else if (roomKind == 5)
            {
                randomRoom = Random.Range(0, rooms.actualRooms.Length);
                Instantiate(rooms.actualRooms[randomRoom], transform.position, rooms.actualRooms[randomRoom].transform.rotation);
            }
            else if (roomKind == 51)
            {
                randomRoom = Random.Range(0, rooms.actualRooms.Length);
                Instantiate(rooms.actualRooms[randomRoom], transform.position, this.transform.rotation * Quaternion.Euler(0, 180, 0));
            }
            else if (roomKind == 52)
            {
                randomRoom = Random.Range(0, rooms.actualRooms.Length);
                Instantiate(rooms.actualRooms[randomRoom], transform.position, this.transform.rotation * Quaternion.Euler(0, 90, 0));
            }
            spawned = true;
        }
        //else
        //{
        //    if (roomKind == 1)
        //    {
        //        randomRoom = Random.Range(0, rooms.actualRooms.Length);
        //        Instantiate(rooms.actualRooms[randomRoom], transform.position, rooms.actualRooms[randomRoom].transform.rotation);
        //    }
        //    else if (roomKind == 2)
        //    {
        //        randomRoom = Random.Range(0, rooms.actualRooms.Length);
        //        Instantiate(rooms.actualRooms[randomRoom], transform.position, rooms.actualRooms[randomRoom].transform.rotation);
        //    }
        //    else if (roomKind == 3)
        //    {
        //        randomRoom = Random.Range(0, rooms.actualRooms.Length);
        //        Instantiate(rooms.actualRooms[randomRoom], transform.position, rooms.actualRooms[randomRoom].transform.rotation);
        //    }
        //    else if (roomKind == 4)
        //    {
        //        randomRoom = Random.Range(0, rooms.actualRooms.Length);
        //        Instantiate(rooms.actualRooms[randomRoom], transform.position, rooms.actualRooms[randomRoom].transform.rotation);
        //    }
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
