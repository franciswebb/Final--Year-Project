using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    public GameObject player;

    static public int score = 0; //variables which are kept throughout the game.
    static public int health = 10;
    static public int maxHealth = 10;
    static public float moveSpeed = 5;
    static public bool enemyHealthShow = false;
    public Text scoreText;
    public Text healthText;



    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        scoreText = GameObject.FindGameObjectWithTag("playerScore").GetComponent<Text>(); //setting the health and score UI elements

        scoreText.text = "Score: " + score;
        healthText.text = health + " / " + maxHealth;
        errorCheck();
        
    }

    public void errorCheck()
    {
        if (health > maxHealth) //error catches
        {
            health = maxHealth;
        }
        if (moveSpeed < 2)
        {
            moveSpeed = 2;
        }
    }

    public void reset() //variables reset if player wins or dies
    {
        moveSpeed = 5;
        maxHealth = 10;
        score = 0;
        health = 10;
        enemyHealthShow = false;
    }

    public void heal() //heals the player
    {
        if(health < maxHealth)
        {
            health = health + 1;
        }
        
    }

    public void moveSpeedUp(float speedUp)// increases the players movement speed
    {
        moveSpeed += speedUp;

    }
    public void moveSpeedDown(float speedDown) // decreases the players movement speed
    {
        moveSpeed -= speedDown;
    }

    public void maxUp(int maxUp) // increases the players max health
    {
        maxHealth += maxUp;

    }
    public void maxDown(int maxDown) //decreases the players max health
    {
        maxHealth -= maxDown;

    }
    public void enemyHealthBarShow() //enables enemy health bars
    {
        enemyHealthShow = true;

    }


}
