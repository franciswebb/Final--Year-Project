using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBomb : MonoBehaviour {

    public GameObject player, explosion, bomb;
    public Vector3 playerLocation;
    public float speed;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLocation = player.transform.position;                 //obtains the players position
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = Vector2.MoveTowards(this.transform.position, playerLocation, (speed * Time.deltaTime));       //moves towards players position
        if (this.transform.position == playerLocation)
        {
            bomb = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;                          //spawns explosion if reaches point
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)                                                                                     //spawns explosion if hits player or wall 
    {
        if (other.tag == "Player")
        {
            bomb = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
            Destroy(this.gameObject);
        }
        if (other.tag == "wall")
        {
            bomb = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
            Destroy(this.gameObject);
        }
    }
}
