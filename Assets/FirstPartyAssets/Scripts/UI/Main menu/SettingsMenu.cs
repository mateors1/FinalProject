using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer masterAudioMixer;
    [SerializeField] private AudioMixer sfxAudioMixer;
    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void ChangeVolume(float volume)
    {
        masterAudioMixer.SetFloat("MusicVolume", volume);
    }

    public void ChangeVolumeSFX(float volume)
    {
        sfxAudioMixer.SetFloat("SFXVolume", volume);
    }
}
