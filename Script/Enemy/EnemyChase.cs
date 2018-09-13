using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{

    public float speed;
    public bool dropper, doOnce = true;
    public GameObject drops;
    public Transform player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //finds player in scene.
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //moves enemy towards player

        if (dropper == true && doOnce == true)
        {
            doOnce = false;
            StartCoroutine("droplet");
        }
    }

    public IEnumerator droplet() //if the enemy is a dropper enemy it will drop a small damaging gameobject every few seconds.
    {
        yield return new WaitForSeconds(3);
        Instantiate(drops, transform.position, transform.rotation);
        doOnce = true;
    }
}
