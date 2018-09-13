using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public int health;
    public int maxHealth;
    public bool death = false;
    public Slider healthBar;
    public bool playerImmune = false;
    public int immuneTime = 2;
    
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        health = playerManager.health;
        maxHealth = playerManager.maxHealth;
        
        healthBar.value = playerManager.health;
        healthBar.maxValue = playerManager.maxHealth;

        if (health <= 0)
        {
            death = true;
        }

        if (death == true)
        {
            PlayerDied();
        }
    }
    public void healthDown()
    {
        if (playerImmune == false)
        {
            playerManager.health -= 1;
            playerImmune = true;
            StartCoroutine(Immune());
        }
    }

    public int getHealth()
    {
        return health;
    }
   
    void PlayerDied()
    {
       
        SceneManager.LoadScene("Died");
    }

    IEnumerator Immune()
    {
        yield return new WaitForSeconds(immuneTime);
        playerImmune = false;
    }

}