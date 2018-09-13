using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotRateUp : MonoBehaviour {

    WeaponController Manage;
    // Use this for initialization
    void Start()
    {
        Manage = FindObjectOfType<WeaponController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Manage.shotSpeedUp();
            Destroy(gameObject);
            Debug.Log("shotSpeedUp");
        }
    }
}
