using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    static public float WeaponDamage = 1;
    static public float weaponDelay = 1f;
    static public bool piercing = false, bomb = false, burn = false, tripleShot = false, doubleShot = false;
    static public float weaponForce = 5, range = 2;
    // Use this for initialization
    void Start()
    {
        //  bulletClones = FindObjectOfType<BulletController>();

    }

    // Update is called once per frame
    void Update()
    {
        //  bullet = GameObject.FindGameObjectsWithTag("bullet");

        if (WeaponDamage < 0.2f)
        {
            WeaponDamage = 0.2f;
        }
        if (weaponDelay < 0.3f)
        {
            weaponDelay = 0.3f;
        }
        if (range < 1)
        {
            range = 1;
        }
    }

    public void reset()
    {
        WeaponDamage = 1;
        weaponDelay = 1f;
        piercing = false;
        bomb = false;
        burn = false;
        doubleShot = false;
        tripleShot = false;
    }

    public void DamageUp()
    {
        WeaponDamage += 0.2f;
    }

    public void DamageDown()
    {
        WeaponDamage -= 0.2f;
    }

    public void shotSpeedDown()
    {
        weaponDelay -= 0.2f;
    }

    public void shotSpeedUp()
    {
        weaponDelay += 0.2f;
    }

    public void weaponForceUp()
    {
        weaponForce += 0.5f;
    }

    public void weaponForceDown()
    {
        weaponDelay -= 0.5f;
    }
    public void rangeUp()
    {
        weaponForce += 0.5f;
    }

    public void rangeDown()
    {
        weaponDelay -= 0.5f;
    }

    public void bombs()
    {
        bomb = true;
    }
    public void pierce()
    {
        piercing = true;
    }
    public void burning()
    {
        burn = true;
    }

    public void tripleShotActive()
    {
        tripleShot = true;
    }

    public void doubleShotActive()
    {
        doubleShot = true;
    }

}
