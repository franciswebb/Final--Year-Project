using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour {

    playerManager Manage;
    public float speedDown = 1;
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
            Manage.moveSpeedDown(speedDown);
            Destroy(gameObject);
            Debug.Log("SpeedDown");
        }
    }
}
