using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushMe : MonoBehaviour
{
    bool wallTrigger;
    public float magnitude;

    void Update()
    {
        magnitude = WeaponController.weaponForce;
    }
    void OnTriggerEnter2D(Collider2D other)
        
    {
        if (other.tag == "enemy" && other.isTrigger == true)
        {
            Vector2 force = transform.position - other.transform.position; //force created

            force.Normalize();
            if (other.GetComponent<Rigidbody2D>() != false)
            {
                other.GetComponent<Rigidbody2D>().AddForce(-force * magnitude, ForceMode2D.Impulse);  // force applied
            }
            
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

  


    }
}