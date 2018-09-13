using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {


    public AudioMixer audioMixer;
    public AudioSource theme;

    // Use this for initialization
    void Start () {
		
	}

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume); // sets master volumer to slider
    }

    // Update is called once per frame
    void Update () {
		
	}
}
