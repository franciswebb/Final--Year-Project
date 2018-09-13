using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnItem : MonoBehaviour
{

    public GameObject[] item; //array of available items

    void Start()
    {
        spawnNewItem();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnNewItem()     //chooses a random item from array and spawns it
    {
        int items = Random.Range(0, item.Length);
        Instantiate(item[items], transform.position, transform.rotation);  
    }



}
