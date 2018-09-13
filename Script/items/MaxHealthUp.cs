using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthUp : MonoBehaviour {
    public int maxhealthUp = 1;
    playerManager player;
	// Use this for initialization
	void Start () {
      
        player = FindObjectOfType<playerManager>();
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.tag == "Player")
        {
            player.maxUp(maxhealthUp);
            Destroy(gameObject);
            Debug.Log("maxHealthUp");
        }
    }

}
