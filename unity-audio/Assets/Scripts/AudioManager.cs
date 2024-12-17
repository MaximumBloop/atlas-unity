using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer masterMixer;
    // Start is called before the first frame update
    void Start()
    {
        SetBGMLevels();
        SetSFXLevels();
    }

    public void SetBGMLevels()
    {
        masterMixer.SetFloat("BGMVolume", Mathf.Log10(PlayerPrefs.GetFloat("BGM")) * 20);
    }

    public void SetSFXLevels()
    {
        masterMixer.SetFloat("SFXVolume", Mathf.Log10(PlayerPrefs.GetFloat("SFX")) * 20);
    }
    public void SetSFXLevels(float value)
    {
        masterMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
    }
}
