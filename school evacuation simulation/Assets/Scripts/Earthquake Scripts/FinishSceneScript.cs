using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishSceneScript : MonoBehaviour
{
    public TextMeshProUGUI rightAnsText;
    public TextMeshProUGUI totalAnsText;
    public TextMeshProUGUI totalWrongText;

    private int playerRightAns;
    private int playerTotalAns;
    private int playerWrongAns;

    private int currentRightAns=0;
    private int currentTotalAns=0;
    private int currentWrongAns=0;

	public bool isWinScene=false;


    // Start is called before the first frame update
    void Start(){
        playerRightAns = HealthPlayer.GetRightAns();
        playerTotalAns = HealthPlayer.GetTotalAns();
		if(isWinScene) playerWrongAns = HealthPlayer.GetWrongAns();
		Cursor.lockState=CursorLockMode.None;
    }
    void Update(){
        if(currentRightAns<playerRightAns){
            currentRightAns++;
            rightAnsText.text = currentRightAns.ToString();
        }else if(currentTotalAns<playerTotalAns){
            currentTotalAns++;
            totalAnsText.text = currentTotalAns.ToString();
        }
		if(isWinScene){
			if(currentWrongAns<playerWrongAns){
				currentWrongAns++;
				totalWrongText.text = currentWrongAns.ToString();
			}
		}
    }
}
