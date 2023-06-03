using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
	public TextMeshProUGUI timer;
    public static float timerValue = 300;
    public AudioSource countSound;
    bool playCountSound = true;
    public AudioSource lightningSound;
    public GameObject showLosingCanvas;
    public bool stopTimer = false;
    public GameObject waterPlane;
   
    // Update is called once per frame
    void Update()
    {
        if(!stopTimer){
            if(timerValue>0){
                timerValue -= Time.deltaTime;
            }else{
                timerValue = 0;
                Cursor.lockState=CursorLockMode.None;
                showLosingCanvas.SetActive(true);
            }
            DisplayTime(timerValue);
        }
    }
    public void AdjustWater(){
        InvokeRepeating("AddWater", 0.1f, 0.1f);
    }
    void AddWater(){
        if(timerValue>0 && timerValue<150){
            waterPlane.transform.localPosition = new Vector3(waterPlane.transform.localPosition.x, waterPlane.transform.localPosition.y+(0.4f/(2.5f*60*24)), waterPlane.transform.localPosition.z);
        }
    }
    void DisplayTime(float timeToDisplay){
        if(timeToDisplay<0){
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay%60);
        if(minutes == 0 && seconds < 11){
            timer.color = new Color(255, 0, 0, 255);
            if(playCountSound){
                countSound.Play();
                playCountSound = false;
            } 
        }
        if(minutes == 2 && seconds==30){ 
            lightningSound.Play();
        }
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public void StopTimer(){
        stopTimer = true;
    }
    public void SetTimer(float val){
        timerValue = val;
    } 
    public static float GetTimer(){
        return timerValue;
    }

}
