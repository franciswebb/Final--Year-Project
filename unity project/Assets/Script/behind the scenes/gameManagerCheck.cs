using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerCheck : MonoBehaviour {

    public string sceneName;
    void Update()
    {
        Reset();
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject); //sets the game manager to do not destroy 

        if (FindObjectsOfType<gameManagerCheck>().Length > 1) 
        {
            Destroy(gameObject);
        }
       
    }
    public void Reset() //resets all static variables when the game starts or resets.
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        if (sceneName == "MainMenu")
        {
            this.gameObject.GetComponent<playerManager>().reset();
            this.gameObject.GetComponent<WeaponController>().reset();
            this.gameObject.GetComponent<gameInfo>().reset();

        }
    }
}
