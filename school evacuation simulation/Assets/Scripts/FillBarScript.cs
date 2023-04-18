using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBarScript : MonoBehaviour
{
    public static int maxPoints = 100;
    public static int currentPoints = 90;
    public PointBar pointBar;
    public GameObject showWinningCanvas;

    TimerScript timerScript;
    [SerializeField] GameObject timerScriptObject;
    void Awake(){
		timerScript = timerScriptObject.GetComponent<TimerScript>();
	}

    // Start is called before the first frame update
    void Start()
    {
        pointBar.SetPoints(currentPoints);
    }

    // Update is called once per frame
    void Update()
    {
        //RightAnswer();
    }
    public void ShowWinningCanvas(){
        if(currentPoints == 100){
            showWinningCanvas.SetActive(true);
            timerScript.StopTimer();
        }
    }

    public void RightAnswer(){
        if(currentPoints<100)
            currentPoints+=10;
        pointBar.SetPoints(currentPoints);
        ShowWinningCanvas();
    }
    public void WrongAnswer(){
        if(currentPoints>0)
            currentPoints-=10;
        pointBar.SetPoints(currentPoints);
    }
}
