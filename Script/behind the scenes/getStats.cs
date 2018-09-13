using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getStats : MonoBehaviour
{

    public int level = 0;
    public float weaponDamage = 0, weaponForce = 0, range = 0, moveSpeed = 0, weaponDelay = 0;
    public Text levelText, damageText, forceText, rangeText, speedText, delayText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        level = gameInfo.level;                             //obtaining player stats from managers
        weaponDamage = WeaponController.WeaponDamage;
        weaponForce = WeaponController.weaponForce;
        weaponDelay = WeaponController.weaponDelay;
        range = WeaponController.range;
        moveSpeed = playerManager.moveSpeed;

        levelText.text = "Bosses Defeated: " + level;       //setting player stats to text boxes on pause canvas
        damageText.text = "Weapon Damage: " + weaponDamage;
        forceText.text = "Weapon Force: " + weaponForce;
        delayText.text = "Weapon Delay: " + weaponDelay;
        rangeText.text = "Weapon Range: " + range;
        speedText.text = "Move Speed: " + moveSpeed;




    }
}
