using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    public AudioMixer audioMixer;

    [SerializeField] private Dropdown graphicsDropdown;
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }                                                                 
        }                                                                     
                                                                              
        resolutionDropdown.AddOptions(options);                               
        //resolutionDropdown.value = currentResolutionIndex;                  
        resolutionDropdown.RefreshShownValue();                               
                                                                              
        if (PlayerPrefs.HasKey("saveVolume"))                                 
        {                                                                     
            LoadVolume();
        }
        else
        {
            SetVolume(volumeSlider.value);
        }

        if (PlayerPrefs.HasKey("saveGraphics"))
        {
            LoadGraphics();
        }
        else
        {
            SetGraphics(graphicsDropdown.value);
        }

        if (PlayerPrefs.HasKey("saveResolutions"))
        {
            LoadResolutions();
        }
        else
        {
            SetResolutions(resolutionDropdown.value);
        }

        if (PlayerPrefs.HasKey("saveFullScreen"))
        {
            LoadFullScreen();
        }
        else
        {
            SetFullScreen(fullScreenToggle.isOn);
        }
    }

    public void SetResolutions(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("saveResolutions", resolutionIndex);
    }

    private void LoadResolutions()
    {
        resolutionDropdown.value = PlayerPrefs.GetInt("saveResolutions");
        SetResolutions(resolutionDropdown.value);
    }
    public void SetVolume(float volume)
    {

        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("saveVolume", volume);
    }

    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("saveVolume");
        SetVolume(volumeSlider.value);
    }

    public void SetGraphics(int graphicsIndex)
    {
        QualitySettings.SetQualityLevel(graphicsIndex);
        PlayerPrefs.SetInt("saveGraphics", graphicsIndex);
    }

    private void LoadGraphics()
    {
        graphicsDropdown.value = PlayerPrefs.GetInt("saveGraphics");
        SetGraphics(graphicsDropdown.value);
    }

    int BoolToInt(bool value)
    {
        if (value)
        {
            return 1;
        }
        else return 0;
    }

    bool IntToBool(int value)
    {
        if (value == 1)
        {
            return true;
        }
        else return false;
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("saveFullScreen", BoolToInt(isFullScreen));
    }

    private void LoadFullScreen()
    {
        fullScreenToggle.isOn = IntToBool(PlayerPrefs.GetInt("saveFullScreen"));
        SetFullScreen(fullScreenToggle.isOn);
    }
}
