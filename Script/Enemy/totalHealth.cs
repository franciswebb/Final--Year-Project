using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totalHealth : MonoBehaviour {

    public float Health = 30;
    float damageToGive;


    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            playerManager.score = playerManager.score + 1; // adding to the score and deleting the enemy

            Destroy(gameObject);
        }

    }

    public void giveDamage()
    {
        damageToGive = WeaponController.WeaponDamage;  // checking how much damage the player currently does and taking it away from the enemy

        Health = Health - damageToGive;

        Debug.Log(Health);
    }
}
