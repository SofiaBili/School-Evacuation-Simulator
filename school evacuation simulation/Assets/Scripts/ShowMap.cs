using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMap : MonoBehaviour
{
    public GameObject mapCanvas;
    public GameObject player;
    public GameObject miniMapCanvas;
    public GameObject miniMapCanvasText;
    public bool canShowMapText = false;
	public bool isMap = true;
    AudioSource[] allAudioSources;
    void Start() {
        allAudioSources = FindObjectsOfType<AudioSource>();
        miniMapCanvasText.SetActive(false);
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
        FireClassScript.stopMovementWhileWalking=true;
        EarthquakeClassScript.stopMovementWhileWalking=true;
        PlayerMovement.StopFromFireMovement();
        PauseAllSources();
        Time.timeScale = 0;
    }
    public void CloseMap(){
        miniMapCanvas.SetActive(true);
        mapCanvas.SetActive(false);
		PlayerMovement.StartFromFireMovement();
		FireClassScript.stopMovementWhileWalking=false;
		EarthquakeClassScript.stopMovementWhileWalking=false;
        PauseAllSources();
        Time.timeScale = 1;
    }
    public void ShowText(){
        canShowMapText = false;
        miniMapCanvasText.SetActive(true);
    }
    void Update() {
        if(!canShowMapText && (EarthquakeClassScript.finishedQuestions || FireClassScript.finishedQuestions)){
            canShowMapText = true;
        }
        if(canShowMapText){
            ShowText();
        }
        if (isMap && Input.GetKeyDown(KeyCode.M) && (EarthquakeClassScript.finishedQuestions || FireClassScript.finishedQuestions)) {
            OpenMap();
        }
        if(!isMap){
			if (Input.GetKeyDown(KeyCode.Escape)) {
				OpenMap();
			}
		}
    }
}
