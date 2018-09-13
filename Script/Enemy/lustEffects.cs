using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lustEffects : MonoBehaviour
{
    GameObject mainCamera;
    bool doOnce = true;
    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && other.isTrigger && doOnce == true) // when the player enters the boss room, camera is turned upside down
        {
            mainCamera.transform.Rotate(0, 0, 180);
            doOnce = false;
            StartCoroutine("wait");
        }
    }


    public IEnumerator wait() // after a few seconds the camera is turned back to normal
    {
        yield return new WaitForSeconds(10);
        mainCamera.transform.Rotate(0, 0, 180);
        StartCoroutine("wait2");
    }
    public IEnumerator wait2() // after a few seconds the camera is turned back upside down again.
    {
        yield return new WaitForSeconds(10);
        doOnce = true;
    }
}
