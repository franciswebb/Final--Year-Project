using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "enemy" && other.isTrigger == true) // DOESNT MATTER ABOUT y FIX
        {
            
            other.GetComponent<EnemyHealth>().giveDamage();
        }


        if (other.tag == "heart" && other.isTrigger == true) // DOESNT MATTER ABOUT y FIX
        { 
            other.GetComponent<heartHealth>().damageBoss();
        }

        
    }
}




