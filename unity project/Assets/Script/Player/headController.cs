using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headController : MonoBehaviour {

    private Animator anim;
    public GameObject bulletRight;
    public GameObject bulletLeft;
    public GameObject bulletUp;
    public GameObject bulletDown;

    GameObject newBullet;
    public bool aimDown, aimUp, aimRight, aimLeft, canshoot = true;
    public float shotDelay = 1;
    WeaponController weapon;
    PlayerController player;

    public Transform bulletspawnUp, up1, up2;
    public Transform bulletspawnRight, right1, right2;
    public Transform bulletspawnLeft, left1, left2;
    public Transform bulletspawnDown, down1, down2;
    
    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindObjectOfType<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {
        if(player.paused == false)
        {
            aimController();
        }
        
        animationStateInitialise();
        shotDelay = WeaponController.weaponDelay;
	}

    #region aiming
    void aimController()
    {
    

        if (Input.GetKey("i"))
        {
           
            newBullet = bulletUp;
            //insert method with weapon control to change bullet stats.
            if (canshoot == true)
            {
                shootBullet(newBullet, bulletspawnUp);
            }
            aimUp = true;
        }
        else if (Input.GetKey("k"))
        {
            newBullet = bulletDown;
            //insert method with weapon control to change bullet stats.
            if (canshoot == true)
            {
                shootBullet(newBullet, bulletspawnDown);
            }

            aimDown = true;
        }
        else if (Input.GetKey("l"))
        {
            newBullet = bulletRight;
            //insert method with weapon control to change bullet stats.
            if (canshoot == true)
            {
                shootBullet(newBullet, bulletspawnRight);
            }

            aimRight = true;
        }
        else if (Input.GetKey("j"))
        {
            newBullet = bulletLeft;
            //insert method with weapon control to change bullet stats.
            aimLeft = true;
            if (canshoot == true)
            {
                shootBullet(newBullet, bulletspawnLeft);
            }

            
        }

        #region resetAim

        if (Input.GetKeyUp("i"))
        {
            aimUp = false;
        }
        if (Input.GetKeyUp("k"))
        {
            aimDown = false;
        }
        if (Input.GetKeyUp("l"))
        {
            aimRight = false;
        }
        if (Input.GetKeyUp("j"))
        {
            aimLeft = false;
        }
        #endregion

    }

    #endregion

    void shootBullet(GameObject bullet, Transform spawn)
    {
        if(WeaponController.tripleShot == true)
        {
            #region tripleshooting

            if (aimLeft == true && canshoot == true)
            {

                Instantiate(bullet, spawn.position, spawn.rotation);
                Instantiate(bullet, left1.position, left1.rotation);
                Instantiate(bullet, left2.position, left2.rotation);
                StartCoroutine(shotWait());
            }

            if (aimRight == true && canshoot == true)
            {

                Instantiate(bullet, spawn.position, spawn.rotation);
                Instantiate(bullet, right1.position, right1.rotation);
                Instantiate(bullet, right2.position, right2.rotation);
                StartCoroutine(shotWait());
            }

            if (aimUp == true && canshoot == true)
            {

                Instantiate(bullet, spawn.position, spawn.rotation);
                Instantiate(bullet, up1.position, up1.rotation);
                Instantiate(bullet, up2.position, up2.rotation);
                StartCoroutine(shotWait());
            }

            if (aimDown == true && canshoot == true)
            {

                Instantiate(bullet, spawn.position, spawn.rotation);
                Instantiate(bullet, down1.position, down1.rotation);
                Instantiate(bullet, down2.position, down2.rotation);
                StartCoroutine(shotWait());
            }
            #endregion
        }
        else if(WeaponController.tripleShot == false && WeaponController.doubleShot == true)
        {
            #region doubleshooting

            if (aimLeft == true && canshoot == true)
            {
                Instantiate(bullet, left1.position, left1.rotation);
                Instantiate(bullet, left2.position, left2.rotation);
                StartCoroutine(shotWait());
            }

            if (aimRight == true && canshoot == true)
            {
                Instantiate(bullet, right1.position, right1.rotation);
                Instantiate(bullet, right2.position, right2.rotation);
                StartCoroutine(shotWait());
            }

            if (aimUp == true && canshoot == true)
            {
                Instantiate(bullet, up1.position, up1.rotation);
                Instantiate(bullet, up2.position, up2.rotation);
                StartCoroutine(shotWait());
            }

            if (aimDown == true && canshoot == true)
            {
                Instantiate(bullet, down1.position, down1.rotation);
                Instantiate(bullet, down2.position, down2.rotation);
                StartCoroutine(shotWait());
            }
            #endregion
        }
        else
        {
                Instantiate(bullet, spawn.position, spawn.rotation);
                StartCoroutine(shotWait());
        }
        

    }

    void animationStateInitialise() // animation setter
    {

        anim.SetBool("aimDown", aimDown);
        anim.SetBool("aimRight", aimRight);
        anim.SetBool("aimLeft", aimLeft);
        anim.SetBool("aimUp", aimUp);

    }// END ANIMATION STATE


    public IEnumerator shotWait()
    {
        canshoot = false;
        yield return new WaitForSeconds(shotDelay);
        canshoot = true;
    }


}
