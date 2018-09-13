using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOverTime : MonoBehaviour {
    public float waitTime;
	// Use this for initialization
	void Start () {
        if(this.gameObject.tag == "bullet")
        {
            waitTime = WeaponController.range;
        }
        StartCoroutine("destroy");
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public IEnumerator destroy()
    {
        
        yield return new WaitForSeconds(waitTime); //destroy game object after certain period of time
        Destroy(this.gameObject);

    }
}
