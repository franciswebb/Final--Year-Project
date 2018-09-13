using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrath : MonoBehaviour {

    public float speed;
    public bool chase = false, shootat = false, shootBombs = false, doOnce = true;
    public int anger;
    private Transform player;
    private shootAtPlayer shoot;
    private MoveBetweenPoints moving;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        shoot = this.gameObject.GetComponent<shootAtPlayer>();
        moving = this.gameObject.GetComponent<MoveBetweenPoints>();
        attackPattern();
    }
	
	// Update is called once per frame
	void Update () {
		if(chase == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if(doOnce == true)
            {
                moving.enabled = false;
                shoot.startShooting = false;
                doOnce = false;
                StartCoroutine("tired");
            }
            

        }
        if (shootat == true)
        {

            if (doOnce == true)
            {
                moving.enabled = true;
                shoot.shootBomb = false;
                shoot.startShooting = true;
                doOnce = false;
                StartCoroutine("tired");
            }

        }
        if (shootBombs == true)
        {
            
            if (doOnce == true)
            {
                moving.enabled = false;
                shoot.shootBomb = true;
                shoot.startShooting = true;
                doOnce = false;
                StartCoroutine("tired");
            }

        }


    }

    public void attackPattern()
    {
        anger = Random.Range(0, 4);
        switch (anger)   // decides which way to attack
        {
            case 0:
                chase = true;
                shootat = false;
                shootBombs = false;

                break;
            case 1:
                chase = false;
                shootat = true;
                shootBombs = false;
                break;
            case 2:
                chase = false;
                shootat = false;
                shootBombs = true;
                break;
            case 3:
                chase = true;
                shootat = true;
                shootBombs = true;
                break;
            default:
                break;
        }
    }

    public IEnumerator tired()
    {
        yield return new WaitForSeconds(8);
        attackPattern();
        doOnce = true;

    }
}
