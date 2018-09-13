using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEnemys : MonoBehaviour
{

    public List<Transform> telespots;
    public GameObject Envy1, Envy2;
    int check1 = 0, check2 = 0;
    bool envyTeleCheck = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnvyAttack();
    }

    public void EnvyAttack()
    {
        if (envyTeleCheck == true)
        {
            envyTeleCheck = false;
            StartCoroutine("teleWait");
        }
    }

    public IEnumerator teleWait()
    {
        yield return new WaitForSeconds(7);
        check1 = Random.Range(0, telespots.Count);
        check2 = Random.Range(0, telespots.Count);
        while (check1 == check2) // make sure enemy not spawned at same spot
        {
            check1 = Random.Range(0, telespots.Count);
        }
        if (Envy1 != null)
        {
            Envy1.transform.position = telespots[check1].position;
        }
        if (Envy2 != null)
        {
            Envy2.transform.position = telespots[check2].position;
        }
        envyTeleCheck = true;
    }
}
