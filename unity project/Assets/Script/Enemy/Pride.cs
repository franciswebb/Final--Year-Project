using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pride : MonoBehaviour {
    public float speed;
    public EnemyHealth health;
    public Transform player;
    public bool chase = true, doOnce = true, secondDoOnce = true, healCheck = true;
    public List<Transform> teles;
    private Health playerHealth;

    // Use this for initialization
    void Start()
    {
        health = this.gameObject.GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chase == true) //moves towards player getting faster.
        {
            doOnce = true;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if(secondDoOnce == true)
            {
                secondDoOnce = false;
                StartCoroutine("tired");
                StartCoroutine("faster");
            }
           
        }
        if(chase == false)
        {
            StopCoroutine("tired");
            StopCoroutine("faster");
            secondDoOnce = true;

            if (healCheck == true)      //starts healing
            {
                healCheck = false;
                StartCoroutine("heal");
            }

            if (doOnce == true)         //waits
            {
                doOnce = false;
                StartCoroutine("prideWait");
            }
        }

    }

    public IEnumerator prideWait() //enemy moves to teleporter spot and waits.
    {
        speed = 2;
        int sleep = Random.Range(0, teles.Count);
        this.transform.position = teles[sleep].position;
        yield return new WaitForSeconds(10);
        chase = true;
    }


    public IEnumerator tired()  // after a certain period of time, enemy will stop chasing
    {
        yield return new WaitForSeconds(12);
        chase = false;
    }


    public IEnumerator faster() //speeds boss up after few seconds
    {
        yield return new WaitForSeconds(3);
        speed += 1;
        secondDoOnce = true;
    }


    public IEnumerator heal() // healing enemy while waiting
    {
        yield return new WaitForSeconds(3);
        health.enemyHealth += 1;
        healCheck = true;
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHealth.healthDown();
            chase = false;
        }
    }
}
