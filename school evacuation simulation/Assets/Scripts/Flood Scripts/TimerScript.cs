using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
	public TextMeshProUGUI timer;
    public float timerValue = 160;
    public AudioSource sound;
    bool playSound = true;
    public GameObject showLosingCanvas;
    public bool stopTimer = false;
    
    // Update is called once per frame
    void Update()
    {
        if(!stopTimer){
            if(timerValue>0){
                timerValue -= Time.deltaTime;
            }else{
                timerValue = 0;
                showLosingCanvas.SetActive(true);
            }
            DisplayTime(timerValue);
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
            if(playSound){
                sound.Play();
                playSound = false;
            } 
        }
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void StopTimer(){
        stopTimer = true;
    }

}
