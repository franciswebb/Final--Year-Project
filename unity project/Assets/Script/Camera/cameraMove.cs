using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {

    public Transform moveCam;
    public BoxCollider2D collider2d;
    public Camera cam;
    public bool camWait = true;
    public float cameraSpeed = 15;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player" && camWait == true)
        {
            Vector3 position = moveCam.position;
            Debug.Log("cam move");
            cam.transform.position = Vector3.Lerp(cam.transform.position, moveCam.position,cameraSpeed *Time.deltaTime);
        }
        
    }

}
