using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float enemyHealth = 5f, enemyMax; // basic enemys health
    float damageToGive;
    public bool burn = false, doOnce = true, burst = false; // unique effects
    public int dropCheck;
    public GameObject drop, baby; //unique effects

    void Start()
    {
        if (gameInfo.level < 3)
        {
           enemyHealth += 5;
           enemyMax = enemyHealth;

        }
        if (gameInfo.level == 4)
        {
            enemyHealth += 8;
            enemyMax = enemyHealth;
        }
        if (gameInfo.level > 5)
        {
            enemyHealth += 10;
            enemyMax = enemyHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            if (drop != null)
            {
                if (burst == true) // if the enemy is a burst enemy it will spawn two smaller enemies when destroyed
                {
                    Instantiate(baby, transform.position, transform.rotation);
                    Instantiate(baby, transform.position, transform.rotation);
                }
                else
                {
                    dropCheck = Random.Range(0, 20); // drops for the player to use (health pick ups)
                    if (dropCheck > 15)
                    {
                        Instantiate(drop, transform.position, transform.rotation);
                    }
                }

            }
            playerManager.score = playerManager.score + 1; // adding to the score and deleting the enemy

            Destroy(gameObject);
        }
        if (burn == true && doOnce == true)
        {
            doOnce = false;
            StartCoroutine("burning");
        }
    }

    public void giveDamage()
    {
        damageToGive = WeaponController.WeaponDamage;  // checking how much damage the player currently does and taking it away from the enemy

        enemyHealth = enemyHealth - damageToGive;

        Debug.Log(enemyHealth);
    }

    public IEnumerator burning() //applies a burning effect which damages enemy over time.
    {
        yield return new WaitForSeconds(3);
        enemyHealth -= 0.5f;
        Debug.Log("burn Damage");
        doOnce = true;
    }
}

