using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piercing : MonoBehaviour {


    WeaponController weapon;
    // Use this for initialization
    void Start()
    {
        weapon = FindObjectOfType<WeaponController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            weapon.pierce();
            Destroy(gameObject);
            Debug.Log("piercing");
        }
    }
}
