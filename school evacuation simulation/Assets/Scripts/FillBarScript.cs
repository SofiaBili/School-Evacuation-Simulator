using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBarScript : MonoBehaviour
{
    public static int maxPoints = 100;
    public static int currentPoints = 0;
    public PointBar pointBar;
    public GameObject showWinningCanvas;
    public GameObject showLosingCanvas;

    public static TimerScript  timerScript;
    [SerializeField] GameObject timerScriptObject;

    static bool setLosingCanvasActive = false;
    
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
        if(setLosingCanvasActive){
            showLosingCanvas.SetActive(true);
            Debug.Log(showLosingCanvas.activeSelf);
        }
    }
    public bool ShowWinningCanvas(){
        if(currentPoints == 100){
            showWinningCanvas.SetActive(true);
            timerScript.StopTimer();
            return true;
        }
        return false;
    }

    public void ShowLosingCanvas(){
            Debug.Log("gggggggggggggggg");
            timerScript.StopTimer();
            setLosingCanvasActive=true;
        //
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
