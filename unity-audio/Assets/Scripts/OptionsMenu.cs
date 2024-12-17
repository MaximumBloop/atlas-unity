using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    bool isOn;
    public Toggle invertToggle;
    public Slider BGMSlider;
    public Slider SFXSlider;
    // Start is called before the first frame update
    // void Start()
    // {
    //     PlayerPrefs.SetInt("InvertYAxis", 0);
    //     PlayerPrefs.Save();
    // }
    void Awake()
    {
        if (!PlayerPrefs.HasKey("InvertYAxis"))
        {
            Debug.Log("Creating InvertYAxis");
            PlayerPrefs.SetInt("InvertYAxis", 0);
            PlayerPrefs.Save();
        }

        isOn = PlayerPrefs.GetInt("InvertYAxis") == 1;

        if (invertToggle != null)
        {
            invertToggle.isOn = isOn;
        }

        if (PlayerPrefs.HasKey("BGM"))
        {
            BGMSlider.value = PlayerPrefs.GetFloat("BGM");
        } else
        {
            PlayerPrefs.SetFloat("BGM", BGMSlider.value);
        }

        if (PlayerPrefs.HasKey("SFX"))
        {
            SFXSlider.value = PlayerPrefs.GetFloat("SFX");
        } else
        {
            PlayerPrefs.SetFloat("SFX", SFXSlider.value);
        }
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBGMVolume(float sliderValue)
    {
        PlayerPrefs.SetFloat("BGM", sliderValue);
    }

    public void SetSFXVolume(float sliderValue)
    {
        PlayerPrefs.SetFloat("SFX", sliderValue);
    }

    public void InvertYAxis()
    {
        isOn = !isOn;
        PlayerPrefs.SetInt("InvertYAxis", isOn ? 1: 0);
        Debug.Log("Toggling InvertedYAxis");
        Debug.Log("InvertYAxis: " + PlayerPrefs.GetInt("InvertYAxis"));
    }

    public void Apply()
    {
        Debug.Log("Saved Preferences!");
        PlayerPrefs.Save();
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
