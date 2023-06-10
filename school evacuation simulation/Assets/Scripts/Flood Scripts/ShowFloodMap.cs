using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFloodMap : MonoBehaviour
{
    public GameObject mapCanvas;
    public GameObject miniMapCanvas;
	public bool isMap = true;
    AudioSource[] allAudioSources;
    void Start() {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }
    void PauseAllSources(){
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach(AudioSource a in allAudioSources){
            if (a.isActiveAndEnabled == true){
                if (a.isPlaying) a.Pause();
                else a.UnPause();
            }
        }

    }
    public void QuitGame(){
      Application.Quit();
    }
    public void OpenMap(){
        mapCanvas.SetActive(true);
        miniMapCanvas.SetActive(false);
        PauseAllSources();
        Time.timeScale = 0;
        if(GuideScript.finishedGuide){
            RotatePlayer.escapeFlag = true;
            Cursor.lockState=CursorLockMode.None;
        }
    }
    public void CloseMap(){
        miniMapCanvas.SetActive(true);
        mapCanvas.SetActive(false);
        Time.timeScale = 1;
        PauseAllSources();
        if(GuideScript.finishedGuide){
            RotatePlayer.escapeFlag = false;
            Cursor.lockState=CursorLockMode.Locked;
        }
    }
    void Update() {
        if (isMap && Input.GetKeyDown(KeyCode.M) && GuideScript.finishedGuide) {
            OpenMap();
        }
		if(!isMap){
			if (Input.GetKeyDown(KeyCode.Escape)) {
				OpenMap();
			}
		}
    }
}
