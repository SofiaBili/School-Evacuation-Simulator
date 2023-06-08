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

    void Start() {
        //player = GameObject.Find("Player");
        //miniMapCanvas = player.transform.Find("MiniMapCanvas").gameObject;
        //miniMapCanvasText =  player.transform.Find("MiniMapCanvasText").gameObject;
        miniMapCanvasText.SetActive(false);
    }

    public void OpenMap(){
        mapCanvas.SetActive(true);
        miniMapCanvas.SetActive(false);
        FireClassScript.stopMovementWhileWalking=true;
        EarthquakeClassScript.stopMovementWhileWalking=true;
        PlayerMovement.StopFromFireMovement();
        Time.timeScale = 0;
    }
    public void CloseMap(){
        miniMapCanvas.SetActive(true);
        mapCanvas.SetActive(false);
		PlayerMovement.StartFromFireMovement();
		FireClassScript.stopMovementWhileWalking=false;
		EarthquakeClassScript.stopMovementWhileWalking=false;
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
        if (Input.GetKeyDown(KeyCode.M) && (EarthquakeClassScript.finishedQuestions || FireClassScript.finishedQuestions)) {
            OpenMap();
        }
    }
}
