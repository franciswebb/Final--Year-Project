using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{

    public string sceneName;


    void Update() //checking the players current level and changes the scene dependant on it.
    {
        winCheck();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // adds to the levels and reloads the scene
        {
            gameInfo.level++;
            SceneManager.LoadScene(sceneName);
        }
    }
    void winCheck()
    {
        if (gameInfo.level > 6)
        {
            sceneName = "Win";
        }
    }
}
