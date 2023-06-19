using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
	public TextMeshProUGUI timer;
    public static float timerValue = 600;
    public AudioSource countSound;
    bool playCountSound = true;
    public AudioSource lightningSound;
    public GameObject showLosingCanvas;
    private static bool stopTimer;
    public GameObject waterPlane;
   
    void Start(){
        stopTimer = false;
    }
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
        if(timerValue>0 && timerValue<570 && waterPlane.transform.localPosition.y<0.4f){
            waterPlane.transform.localPosition = new Vector3(waterPlane.transform.localPosition.x, waterPlane.transform.localPosition.y+(0.4f/(5700)), waterPlane.transform.localPosition.z);
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
        if(minutes == 9 && seconds==30){ 
            lightningSound.Play();
        }
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public void StopTimer(){
        Debug.Log("pppppppppppppppppppp");
        stopTimer = true;
    }
    public void StartTimer(){
        stopTimer = false;
    }

    public void SetTimer(float val){
        timerValue = val;
    } 
    public static float GetTimer(){
        return timerValue;
    }

}
