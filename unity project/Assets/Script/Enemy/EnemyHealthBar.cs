using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Canvas EnemyBar;
    public Slider healthbar;
    public EnemyHealth health;

    // Use this for initialization
    void Start()
    {
        healthbar.maxValue = health.enemyMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.enemyHealthShow == false)
        {
            EnemyBar.enabled = false;
        }
        else
        {
            EnemyBar.enabled = true;
        }
        healthbar.value = health.enemyHealth;
    }
}