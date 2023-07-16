using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioMixer MusicMixer;
    public Slider MusicSlider;
    public Slider SFXSlider;

    void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
    }

    public void SetMusicLevel(float MusicSliderValue)
    {
        MusicMixer.SetFloat("MusicVol", Mathf.Log10(MusicSliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", MusicSliderValue);
    }

    public void SetSFXLevel(float SFXSliderValue)
    {
        MusicMixer.SetFloat("SFXVol", Mathf.Log10(SFXSliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", SFXSliderValue);
    }
}
