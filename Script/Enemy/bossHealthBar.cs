using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossHealthBar : MonoBehaviour {

    public Slider healthbar;
    public GameObject boss;
    public EnemyHealth health;

    // Use this for initialization
    void Start () {
        health = this.gameObject.GetComponent<EnemyHealth>();
        healthbar.maxValue = health.enemyHealth;
	}
	
	// Update is called once per frame
	void Update () {
        healthbar.value = health.enemyHealth;
	}
}
