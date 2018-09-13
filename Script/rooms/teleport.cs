using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {
    public Transform teleTransform;
    public BoxCollider2D collider2d;
    public MeshRenderer render;


    public bool roomCheck = false;

    // Use this for initialization
    void Start () {
        collider2d = GetComponent<BoxCollider2D>();
        render = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (roomCheck == false)
        {
            render.enabled = false;
            collider2d.enabled = false;
        }
        else if (roomCheck == true)
        {
            render.enabled = true;
            collider2d.enabled = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" )
        {
            other.transform.position = teleTransform.position;
            
        }
    }

}
