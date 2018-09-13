using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomCheck : MonoBehaviour {

    public teleport tele;
    public Transform bossRoom;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "room")
        {
            tele.roomCheck = true;

        }
        if (other.tag == "bossRoom")
        {
            tele.roomCheck = true;
            bossRoom = GameObject.FindGameObjectWithTag("bossRoomTele").transform;
            tele.teleTransform = bossRoom;
        }

    }
}
