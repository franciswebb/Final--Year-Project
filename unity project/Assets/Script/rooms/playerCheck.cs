using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCheck : MonoBehaviour
{
    private bool playerEnter = false;

    public int totalEnemys = 0;

    public List<GameObject> enemies;
    public List<GameObject> teleporters;    //lists of enemies and teleporters in current room
    public List<GameObject> items;
    public spawningEnemies spawning;
    public bool spawnedItem = false;
    public int spawnNum;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (totalEnemys == 0)  // when all enemies have been destroyed, turn on teleporters
        {
            foreach (GameObject go in teleporters)
            {
                if (go.name == "NextLevel")  //next level teleporters dont have roomchecks
                {
                    go.SetActive(true);
                    if (spawnedItem == true)
                    {
                        spawnedItem = false;
                        spawnNum = Random.Range(0, items.Count);
                        Instantiate(items[spawnNum], transform.position, transform.rotation);   //spawns random item after beating boss.
                    }
                }
                else
                {
                    if (go.GetComponent<teleport>().roomCheck == true)  //checks if teleporter is attached to another room, if so turns on.
                    {
                        go.SetActive(true);
                    }
                }
            }

        }
        if (totalEnemys < 0) // just in case
        {
            totalEnemys = 0;
        }

        if (totalEnemys == 0 && playerEnter == true)  // clearing rooms if player has already entered a room incase of errors
        {

            foreach (GameObject go in teleporters)
            {
                if (go.name != "NextLevel")
                {
                    if (go.GetComponent<teleport>().roomCheck == true)  //activating next level teleporter
                    {
                        go.SetActive(true);
                    }
                    enemies.Clear();
                }
            }

        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "enemy" && other.isTrigger) //removing from total number of enemies in room
        {
            totalEnemys--;
            spawnedItem = true;
        }

        if (other.tag == "Player" && other.isTrigger)
        {
            foreach (GameObject go in enemies) //destroys any enemies when player leaves the room
            {
                Destroy(go);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Teleport")
        {

            if (!teleporters.Contains(other.gameObject)) // adding teleporters to script
            {
                teleporters.Add(other.gameObject);
            }

            foreach (GameObject go in teleporters)
            {
                go.SetActive(false);
            }
        }
        if (other.tag == "Player" && other.isTrigger) //spawning enemy
        {
            playerEnter = true;
            if (!spawning == false)
            {
                spawning.spawn = true;
            }
        }

        if (other.tag == "enemy") // adding enemy to totalEnemies
        {
            if (!enemies.Contains(other.gameObject))
            {
                enemies.Add(other.gameObject);
                totalEnemys++;
            }

            /*
            if (playerEnter == false)
            {
               
                foreach (GameObject go in enemies)
                {
                    go.GetComponent<EnemyChase>().enabled = false;
                }
            }*/
        }
    }


}
