using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour {



    public void GoToScene(string sceneName) // changes the scene
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame() // exits the game
    {
        Application.Quit();
    }
    public void UnPause() // unpauses the game
    {
        Time.timeScale = 1f;
       
    }
}
