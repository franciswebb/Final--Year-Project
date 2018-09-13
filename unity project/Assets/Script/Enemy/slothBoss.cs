using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slothBoss : MonoBehaviour
{

    public GameObject player;
    public Vector3 playerLocation;
    public float speed = 1;
    public int tiredTime = 8;
    private int reset = 15;
    public bool active = true, doOnce = false;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLocation = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        chase();
    }

    public void chase()
    {
        if (active == true)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, playerLocation, (speed * Time.deltaTime));
        }

        if (this.transform.position == playerLocation)
        {
            active = false;
        }
        if (active == false && doOnce == false)
        {
            StartCoroutine("tired");
        }
        if (reset == 10)
        {
            speed = +3;
        }
        if (tiredTime < 0)
        {
            tiredTime = 0;
        }
        if (reset <= 0)
        {
            tiredTime = 5;
            speed = 1;
            reset = 15;
        }
    }

    public IEnumerator tired()
    {
        doOnce = true;
        yield return new WaitForSeconds(tiredTime);
        speed += 0.5f;
        tiredTime -= 1;
        reset--;
        player = GameObject.FindGameObjectWithTag("Player");
        playerLocation = player.transform.position;
        active = true;
        doOnce = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            reset = 0;
            active = false;
        }

    }


}
