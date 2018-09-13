using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameInfo : MonoBehaviour
{

    static public int level = 0;  // this script is used to hold the current number of bosses defeated(level) and the bosses defeated, used for enemy spawn and level generation.
    public List<GameObject> bosses;

    public void reset()
    {
        level = 0;
        bosses.Clear();
    }

    
}
