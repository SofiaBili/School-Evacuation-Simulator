using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFloodMap : MonoBehaviour
{
    public GameObject mapCanvas;
    public GameObject miniMapCanvas;

    void Start() {
    }

    public void OpenMap(){
		RotatePlayer.escapeFlag = true;
        Cursor.lockState=CursorLockMode.None;
        mapCanvas.SetActive(true);
        miniMapCanvas.SetActive(false);
        Time.timeScale = 0;
    }
    public void CloseMap(){
		RotatePlayer.escapeFlag = false;
        Cursor.lockState=CursorLockMode.Locked;
        miniMapCanvas.SetActive(true);
        mapCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.M) && GuideScript.finishedGuide) {
            OpenMap();
        }
    }
}
