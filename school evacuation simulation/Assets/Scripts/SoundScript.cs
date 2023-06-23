using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour
{
    [SerializeField] Slider sfxSlider;
    [SerializeField] AudioMixer mixer;

    void Start(){
        sfxSlider.value=PlayerPrefs.GetFloat("SfxVolume");
        ChangeMixerSfx();
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