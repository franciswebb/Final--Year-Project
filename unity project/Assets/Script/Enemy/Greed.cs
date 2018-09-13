using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greed : MonoBehaviour {

    private WeaponController weapon;
    private playerManager playerMan;

    public List<Transform> spots;

    public float speed = 2;
    public EnemyHealth health;
    public Transform player;
    public bool chase = true;
    private shootAtPlayer shoot;
    bool doOnce1 = true, doOnce2 = false;
    private Health playerHealth;
    private int s;
    public int greedy;


    // Use this for initialization
    void Start () {

        health = this.gameObject.GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        weapon = FindObjectOfType<WeaponController>();
        playerMan = FindObjectOfType<playerManager>();
        shoot = this.gameObject.GetComponent<shootAtPlayer>();
        playerHealth = FindObjectOfType<Health>();

        greedy = Random.Range(0, 5);

        switch (greedy)   // steals players stats
        {
            case 1:   
                weapon.DamageDown();
                
                break;
            case 2:
                playerMan.moveSpeedDown(1);
                speed++;
                break;
            case 3:
                weapon.shotSpeedDown();
                shoot.waitTime = shoot.waitTime - 0.2f;
                break;
            case 4:
                if (playerManager.maxHealth > 1 && playerManager.health >1)
                {
                    playerMan.maxDown(1);
                    playerHealth.healthDown();
                }
                
                health.enemyHealth += 10;
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if(health.enemyHealth == 0)
        {
            switch (greedy)   // returns stats to players 
            {
                case 1:
                    weapon.DamageUp();
                    weapon.DamageUp();
                    break;
                case 2:
                    playerMan.moveSpeedUp(2);
                  
                    break;
                case 3:
                    weapon.shotSpeedUp();
                    weapon.shotSpeedUp();
                    break;
                case 4:
                    playerMan.maxUp(2);
                    break;
                default:
                    break;
            }
        }


                            //chases the player until tired, then moves to point shooting player

        if (chase == true)
        {
            shoot.startShooting = false;
            if(doOnce1 == true)
            {
                doOnce1 = false;
                doOnce2 = true;
                StartCoroutine("tired");
            }
            
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            

        }
        if (chase == false)
        {
            shoot.startShooting = true;
            if (doOnce2 == true)
            {
                doOnce2 = false;
                doOnce1 = true;
                s = Random.Range(0, spots.Count);
            }
            transform.position = Vector2.MoveTowards(transform.position, spots[s].position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "point")
        {
            chase = true;
        }

    }
    public IEnumerator tired()
    {
        yield return new WaitForSeconds(10);
        chase = false;
    }

}
