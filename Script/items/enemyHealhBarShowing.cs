using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealhBarShowing : MonoBehaviour {

    playerManager Manage;
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
            Manage.enemyHealthBarShow();
            Destroy(gameObject);
            Debug.Log("enemyHealthBarShowing");
        }
    }
}
