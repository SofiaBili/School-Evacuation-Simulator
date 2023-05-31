using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] AudioMixer mixer;

    void Start(){
        musicSlider.value=PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value=PlayerPrefs.GetFloat("SfxVolume");
        ChangeMixerMusic();
        ChangeMixerSfx();
    }

    public void ChangeMusicVolume(){
        PlayerPrefs.SetFloat("MusicVolume",musicSlider.value);
        ChangeMixerMusic();
        PlayerPrefs.Save();
    }

    public void ChangeSfxVolume(){
        PlayerPrefs.SetFloat("SfxVolume",sfxSlider.value);
        ChangeMixerSfx();
        PlayerPrefs.Save();
    }

    private void ChangeMixerMusic(){
        mixer.SetFloat("Music",musicSlider.value);
    }

    private void ChangeMixerSfx(){
        mixer.SetFloat("SFX",sfxSlider.value);
    }
}