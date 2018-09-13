using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartHealth : MonoBehaviour {

    public totalHealth bossHealth;

	// Use this for initialization
	void Start () {
        bossHealth = FindObjectOfType<totalHealth>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void damageBoss()
    {
        bossHealth.giveDamage();
    }

}
