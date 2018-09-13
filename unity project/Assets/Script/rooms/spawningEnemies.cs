using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawningEnemies : MonoBehaviour {

    public GameObject[] Enemies;
    public Transform[] spawnPoints;
    public bool spawn = false, doOnce = false, boss = false;
    public gameInfo game;
    private int errorCheck = 0;

    // Use this for initialization
    void Start()
    {
        game = FindObjectOfType<gameInfo>();

    }

    // Update is called once per frame
    void Update()
    {
        if(spawn == true)
        {
            if(doOnce == false)
            {
                spawnNewEnemies();      //spawning enemies on spawn points once
                doOnce = true;
            }
        }
    }

    public void spawnNewEnemies()
    {

        if (spawnPoints.Length == 0)
        {
            if (boss == true)
            {
                int enemyNum = Random.Range(0, Enemies.Length);     //random boss chosen
                while(game.bosses[enemyNum] != null)
                {
                    enemyNum = Random.Range(0, Enemies.Length);     //chosing a different boss
                    errorCheck++;
                    if(errorCheck > 50)                             //making sure game does not get stuck
                    {
                        game.bosses[enemyNum] = null;
                    }
                }
                
                game.bosses[enemyNum] = Enemies[enemyNum];          //setting game info boss list to current boss and spawning
                Instantiate(Enemies[enemyNum], transform.position, transform.rotation);
            }
            else
            {
                
                int enemyNum = Random.Range(0, Enemies.Length);
                Instantiate(Enemies[enemyNum], transform.position, transform.rotation);
            }
        }
        else
        {
            for (int i = 0; i < spawnPoints.Length; i++)        //random enemy chosen for each point
            {
                int enemyNum = Random.Range(0, Enemies.Length);
                Instantiate(Enemies[enemyNum], spawnPoints[i].position, spawnPoints[i].rotation);
            }
        }
    }

}
