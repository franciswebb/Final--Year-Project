using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour{  //using Brakceys online tutorial https://www.youtube.com/watch?v=YOaYQrN1oYQ


    public Dropdown resolutionDrop;
    Resolution[] resolutions;
    public Toggle full;
    Resolution res;

    void Start()
    {
        resolutions = Screen.resolutions;  // sets the available screen resolutions into an array
        resolutionDrop.ClearOptions();
        List<string> options = new List<string>();  // creating a new list of strings to hold screen resolutions

        int currentResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)  // for loop to convert array of resoultions into list of strings.
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) // checking current screen resolution
            {
                currentResolution = i;
            }
        }

        resolutionDrop.AddOptions(options);
        resolutionDrop.value = currentResolution; // sets current screen resolution to dropdown.
        resolutionDrop.RefreshShownValue();
        if (Screen.fullScreen == true)
        {
            full.isOn = true;
        }
        else
        {
            full.isOn = false;
        }
    }

    public void update()
    {
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; // sets game to fullscreen
    }

    public void SetResolution(int resolutionIndex)
    {
        res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

}
