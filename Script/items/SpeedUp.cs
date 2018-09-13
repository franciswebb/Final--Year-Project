using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {
   
    playerManager Manage;
    public float speedUp = 1;
    // Use this for initialization
    void Start()
    {
        Manage = FindObjectOfType<playerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Manage.moveSpeedUp(speedUp);
            Destroy(gameObject);
            Debug.Log("SpeedUp");
        }
    }
}
