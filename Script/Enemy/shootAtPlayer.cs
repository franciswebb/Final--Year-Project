using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootAtPlayer : MonoBehaviour {

    public GameObject bulletShot, bombShot, bullet;
    public Transform shotPoint;
    public float waitTime = 1.7f;
    public bool startShooting = true, doOnce = false, shootBomb = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (startShooting == true)
        {
            if (doOnce == false)
            {
                if (shootBomb == false)
                {
                    bullet = Instantiate(bulletShot, transform.position, Quaternion.identity) as GameObject;

                    doOnce = true;
                    StartCoroutine(waitTillShoot());
                }
                else
                {
                    bullet = Instantiate(bombShot, transform.position, Quaternion.identity) as GameObject;
                    doOnce = true;
                    StartCoroutine(waitTillShoot());
                }
            }
        }
        

    }
    public IEnumerator waitTillShoot()
    {
        yield return new WaitForSeconds(waitTime);
        doOnce = false;

    }
}
