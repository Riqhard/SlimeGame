using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;

    public static SettingMenu instance;

    Resolution[] resolutions;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int cureResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && 
                resolutions[i].height == Screen.height)
            {
                cureResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = cureResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        
    }

    public void SetVolume(float volume)
    {
        var dbVolume = Mathf.Log10(volume) * 20;

        if (volume == 0.0f)

        {

            dbVolume = -80.0f;

        }

        audioMixer.SetFloat("volume", dbVolume);

    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }
}
