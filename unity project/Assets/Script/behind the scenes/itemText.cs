using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemText : MonoBehaviour {
    public Text itemName;

    // Use this for initialization
    void Start () {
        itemName.text = this.gameObject.name; //used to display items name over item
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
