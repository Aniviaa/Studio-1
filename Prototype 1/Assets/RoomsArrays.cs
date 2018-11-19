using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsArrays : MonoBehaviour {


    /** 
     * Remember to look up ? operator
     * */
    
    public GameObject startRoom;
    public GameObject respawnStartRoom;
    public GameObject[] roomsKindRight;
    public GameObject[] roomsKindBottom;
    public GameObject[] roomsKindTop;
    public GameObject[] roomsKindLeft;

    public GameObject[] actualRooms;
    public GameObject[] halls;

    public GameObject Block;

    public List<GameObject> roomAmount;

    public float time;
    public float startTime;
    public bool bossSpawned;
    public GameObject boss;
    public Vector3 bossPosition;

    private void Start()
    {
        startTime = 3;
        startRoom = GameObject.FindGameObjectWithTag("MainRoom");
    }
    void Update ()
    {
        startTime -= Time.deltaTime;
        if (time <= 0 && !bossSpawned)
        {
            for (int i = 0; i < roomAmount.Count; i++)
            {
                if (i == roomAmount.Count - 1)
                {
                    bossPosition = new Vector3(roomAmount[i].transform.position.x, roomAmount[i].transform.position.y + 1, roomAmount[i].transform.position.z);
                    Instantiate(boss, bossPosition, Quaternion.identity);
                    bossSpawned = true;
                }
            }
        }
        else
        {
            
            time -= Time.deltaTime;
        }


        //if (roomAmount.Count < 10 && time <= 0)
        //{
        //    for (int i = 0; i < roomAmount.Count; i++)
        //    {
        //        Destroy(roomAmount[i].gameObject);
        //    }
        //    Destroy(startRoom.gameObject);
        //    Instantiate(respawnStartRoom, Vector3.zero, Quaternion.identity);
        //}
	}
}
