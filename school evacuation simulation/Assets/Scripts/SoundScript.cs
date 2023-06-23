using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour
{
    [SerializeField] Slider sfxSlider;
    [SerializeField] AudioMixer mixer;
    [SerializeField] GameObject settings;

    void Start(){
        sfxSlider.value=PlayerPrefs.GetFloat("SfxVolume");
        ChangeMixerSfx();
        settings.SetActive(false);
    }

    public void ChangeSfxVolume(){
        PlayerPrefs.SetFloat("SfxVolume",sfxSlider.value);
        ChangeMixerSfx();
        PlayerPrefs.Save();
    }

    private void ChangeMixerSfx(){
        mixer.SetFloat("SFX",sfxSlider.value);
    }
}