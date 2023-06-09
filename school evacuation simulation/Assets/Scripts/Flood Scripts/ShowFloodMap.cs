using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFloodMap : MonoBehaviour
{
    public GameObject mapCanvas;
    public GameObject miniMapCanvas;
	public bool isMap = true;

    void Start() {
    }

    public void OpenMap(){
        if(GuideScript.finishedGuide){
		    RotatePlayer.escapeFlag = true;
            Cursor.lockState=CursorLockMode.None;
        }
        mapCanvas.SetActive(true);
        miniMapCanvas.SetActive(false);
        Time.timeScale = 0;
    }
    public void CloseMap(){
        miniMapCanvas.SetActive(true);
        mapCanvas.SetActive(false);
        Time.timeScale = 1;
        if(GuideScript.finishedGuide){
            Cursor.lockState=CursorLockMode.Locked;
		    RotatePlayer.escapeFlag = false;
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
