using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class optionsMenu : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;
    Resolution[] resolutions;
    [SerializeField]
    Dropdown resolutionDropdown;
    [SerializeField]
    Toggle fullscreenToggle;

    private void Start()
    {
        //add the resolution options to the dropdown
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        //find the current resolution, and set the dropdown to that
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            Debug.Log(Screen.currentResolution.width);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        //set the fullscreen button to whether the game started fullscreen or not
        if(Screen.fullScreen)
        {
            fullscreenToggle.isOn = true;
        }
        else
        {
            fullscreenToggle.isOn = false;
        }
    }

    //change the volume
    public void volumeChange(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    //change whether the game is in fullscreen
    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    //change the resolution
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
