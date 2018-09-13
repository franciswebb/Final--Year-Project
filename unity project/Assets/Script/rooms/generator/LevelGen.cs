using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{

    public GameObject[] Rooms; // array holding different rooms which can be spawned

    public List<Vector3> createdRooms; //list holding the locations where rooms were created
    public int roomAmount;  //total rooms to be spawned
    public int roomSize; // how far the generator will move depending on going horizontal or vertical
    int roomNumber;
    public float waitTime; // testing to see level gen in progress


    // Use this for initialization
    void Start()
    {
       
        if (gameInfo.level < 3)
        {
            roomAmount = 25;
        }
        if (gameInfo.level == 4)
        {
            roomAmount = 30;
        }
        if (gameInfo.level > 5)
        {
            roomAmount = 40;
        }
        StartCoroutine(Generator());

    }

    IEnumerator Generator()
    {
        for (int i = 0; i < roomAmount; i++)    //continues until all rooms have spawned.
        {
            int dir = Random.Range(0, 4);  // deciding which direction to go.
            if (i == 0)
            {
                roomNumber = 0;   // spawn room
            }
            else if (i == (roomAmount - 1))
            {
                roomNumber = 1;   // boss room
            }
            else if (i == 2)
            {
                roomNumber = 2;   // item room
                Debug.Log("itemSpawn");
            }
            else
            {
                roomNumber = Random.Range(2, Rooms.Length);  //any normal room in the array
            }

            createRoom(roomNumber);
            moveGen(dir);
            yield return new WaitForSeconds(waitTime);
        }


        yield return 0;
    }

    void createRoom(int roomNumber) // checks if current location already has a room spawned, if so moves on and adds to total rooms to make sure all spawn.
    {

        if (!createdRooms.Contains(transform.position))
        {
            GameObject RoomObject = Instantiate(Rooms[roomNumber], transform.position, transform.rotation) as GameObject;
            createdRooms.Add(RoomObject.transform.position);

        }
        else
        {
            roomAmount++;
        }
    }



    void moveGen(int dir) //moving the generator in one of 4 directions
    {
        switch (dir)
        {
            case 0:
                roomSize = 10;
                transform.position = new Vector3(transform.position.x, transform.position.y + roomSize, 0);// up

                break;
            case 1:
                roomSize = 19;
                transform.position = new Vector3(transform.position.x + roomSize, transform.position.y, 0);// right

                break;
            case 2:
                roomSize = 10;
                transform.position = new Vector3(transform.position.x, transform.position.y - roomSize, 0);// down

                break;
            case 3:
                roomSize = 19;
                transform.position = new Vector3(transform.position.x - roomSize, transform.position.y, 0); // left


                break;

        }
    }


}



