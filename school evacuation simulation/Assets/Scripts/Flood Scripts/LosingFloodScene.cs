using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LosingFloodScene : MonoBehaviour
{
    public GameObject waterPlane;
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI rightAnsText;
    public TextMeshProUGUI wrongAnsText;

    
    private int playerRightAns;
    private int playerWrongAns;
    private int currentRightAns=0;
    private int currentWrongAns=0;

    // Start is called before the first frame update
    void Start(){
        playerRightAns = FillBarScript.GetRightAns();
        playerWrongAns = FillBarScript.GetWrongAns();
        InvokeRepeating("AddWater", 0.3f, 0.1f);
    }
    void AddWater(){
        if(waterPlane.transform.localPosition.y<1.76){
            waterPlane.transform.localPosition = new Vector3(waterPlane.transform.localPosition.x, waterPlane.transform.localPosition.y+0.06f, waterPlane.transform.localPosition.z);
        }
    }
    void Update(){
        if(currentRightAns<playerRightAns){
            currentRightAns++;
            rightAnsText.text = currentRightAns.ToString();
        }else if(currentWrongAns<playerWrongAns){
            currentWrongAns++;
            wrongAnsText.text = currentWrongAns.ToString();
        }
    }
}
