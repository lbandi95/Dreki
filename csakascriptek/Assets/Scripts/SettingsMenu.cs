using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions=new Resolution[3];
    public Toggle togglefullscreen;

    private void Start()
    {
        
        resolutions[0].width = 1280;
        resolutions[0].height = 720;
        resolutions[1].width = 1600;
        resolutions[1].height = 900;
        resolutions[2].width = 1920;
        resolutions[2].height = 1080;

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentresolutionindex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == 1280 && resolutions[i].height == 720 || resolutions[i].width == 1600 && resolutions[i].height == 900|| resolutions[i].width == 1920 && resolutions[i].height == 1080)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
            }                        
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentresolutionindex = i;
            }
            else
            {
                currentresolutionindex = 0;
            }
                    
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentresolutionindex;
        resolutionDropdown.RefreshShownValue();
        if(Screen.fullScreen)
        {
            togglefullscreen.isOn = true;
        }
        
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
