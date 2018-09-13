using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gluttony : MonoBehaviour
{

    public List<GameObject> hearts;
    public GameObject[] enemy;
    public Transform spawnPoint;
    public bool HealthSwitch = true;
    int healthNum = 0, NewHealthNum = 0, enemyNum = 0;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(false); //turns all hearts off

        }
    }

    // Update is called once per frame
    void Update()
    {
        heartSwitch();
    }

    public void heartSwitch()
    {
        if (HealthSwitch == true) //checking if hearts needs changed
        {
            healthNum = Random.Range(0, hearts.Count);
            if (healthNum != NewHealthNum) // making sure new heart is not the same as current heart
            {
                HealthSwitch = false;
                NewHealthNum = healthNum;

                hearts[healthNum].SetActive(true);
                StartCoroutine("wait");
            }
        }
    }

    public IEnumerator wait()  //waits 10 seconds then activates heart swap and spawns an enemy
    {
        yield return new WaitForSeconds(10);
        hearts[healthNum].SetActive(false);
        enemyNum = Random.Range(0, enemy.Length);
        Instantiate(enemy[enemyNum], spawnPoint.position, spawnPoint.rotation);
        HealthSwitch = true;
    }
}
