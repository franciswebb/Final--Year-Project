using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burnOn : MonoBehaviour {

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
            weapon.burning();
            Destroy(gameObject);
            Debug.Log("burn damage ON");
        }
    }
}
