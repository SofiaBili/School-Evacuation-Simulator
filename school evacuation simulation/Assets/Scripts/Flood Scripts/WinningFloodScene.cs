using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinningFloodScene : MonoBehaviour
{
    public GameObject waterPlane;
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI rightAnsText;
    public TextMeshProUGUI wrongAnsText;

    private float playerTimer;
    private int currentPlayerTimer=0;
    
    private int playerRightAns;
    private int playerWrongAns;
    private int currentRightAns=0;
    private int currentWrongAns=0;


    // Start is called before the first frame update
    void Start()
    {
        playerTimer=180-TimerScript.GetTimer();
        playerRightAns = FillBarScript.GetRightAns();
        playerWrongAns = FillBarScript.GetWrongAns();
        InvokeRepeating("RemoveWater", 0.3f, 0.1f);
    }
    void RemoveWater(){
        if(waterPlane.transform.localPosition.y>0){
            waterPlane.transform.localPosition = new Vector3(waterPlane.transform.localPosition.x, waterPlane.transform.localPosition.y-(1.4f/180f), waterPlane.transform.localPosition.z);
        }
    }
    void PutTime(){
        if(waterPlane.transform.localPosition.y>0){
            waterPlane.transform.localPosition = new Vector3(waterPlane.transform.localPosition.x, waterPlane.transform.localPosition.y-(1.4f/180f), waterPlane.transform.localPosition.z);
        }
    }
    void Update(){
        if(currentPlayerTimer<playerTimer){
            currentPlayerTimer++;
            float minutes = Mathf.FloorToInt(currentPlayerTimer / 60); 
            float seconds = Mathf.FloorToInt(currentPlayerTimer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }else if(currentRightAns<playerRightAns){
            currentRightAns++;
            rightAnsText.text = currentRightAns.ToString();
        }else if(currentWrongAns<playerWrongAns){
            currentWrongAns++;
            wrongAnsText.text = currentWrongAns.ToString();
        }
    }
}
