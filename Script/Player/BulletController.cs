using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject player, explosion, bomb;
    public float velX = 2f;
    public float velY = 0f;
    Rigidbody2D rb;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(velX, velY);
	}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "wall")
        {
            Destroy(this.gameObject);
        }

        if (other.tag == "enemy" && other.isTrigger == true) // DOESNT MATTER ABOUT y FIX
        {
            //    Destroy(other.gameObject);
           if (WeaponController.bomb == true)
            {
                bomb = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
                Destroy(this.gameObject);
            }
            else
            {
                other.GetComponent<EnemyHealth>().giveDamage();
                if(WeaponController.burn == true)
                {
                    other.GetComponent<EnemyHealth>().burn = true;
                }

                if (WeaponController.piercing == false)
                {
                     Destroy(this.gameObject);
                }
            }
            
        }
        if (other.tag == "heart" && other.isTrigger == true) // DOESNT MATTER ABOUT y FIX
        {
            //    Destroy(other.gameObject);
            if (WeaponController.bomb == true)
            {
                bomb = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
                Destroy(this.gameObject);
            }
            else
            {
                other.GetComponent<heartHealth>().damageBoss();
                if (WeaponController.piercing == false)
                {
                    Destroy(this.gameObject);
                }
            }
           
        }

    }
}
