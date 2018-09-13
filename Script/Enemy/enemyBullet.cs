using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour {

    public GameObject player;
    public Vector3 playerLocation;
    public float speed;
    public Health health;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLocation = player.transform.position;                         //gets players current position
        health = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = Vector2.MoveTowards(this.transform.position, playerLocation, (speed * Time.deltaTime));       //moves towards players current position
        if (this.transform.position == playerLocation)                                      
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)                                                                                     //damages player if contact
    {
        if (other.tag == "Player")
        {
            health.healthDown();
            Destroy(this.gameObject);
        }
        if (other.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}
