using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillBarScript : MonoBehaviour
{
    public static int maxPoints = 100;
    public static int currentPoints = 0;
    public PointBar pointBar;
    public GameObject showWinningCanvas;
    public GameObject showLosingCanvas;

    public static TimerScript  timerScript;
    [SerializeField] GameObject timerScriptObject;

    static int rightAns=0;
    static int wrongAns=0;
    static bool setLosingCanvasActive = false;
    
    void Awake(){
		timerScript = timerScriptObject.GetComponent<TimerScript>();
	}
    void OnDestroy(){
        setLosingCanvasActive=false;
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
            //showLosingCanvas.SetActive(true);
            ShowLosingScene();
        }
    }
    public bool ShowWinningCanvas(){
        if(currentPoints == 100){
            Cursor.lockState=CursorLockMode.None;
            timerScript.StopTimer();
            ShowWinningScene();
            return true;
        }
        return false;
    }

    public void ShowLosingCanvas(){
        timerScript.StopTimer();
        setLosingCanvasActive=true;
    }
    public void RightAnswer(){
        if(currentPoints<100)
            currentPoints+=10;
        pointBar.SetPoints(currentPoints);
        rightAns++;
        ShowWinningCanvas();
    }
    public void WrongAnswer(){
        if(currentPoints>0)
            currentPoints-=10;
        wrongAns++;
        pointBar.SetPoints(currentPoints);
    }
    public void ShowWinningScene(){
        SceneManager.LoadScene("WinningFloodScene");
    }
    public void ShowLosingScene(){
        SceneManager.LoadScene("LosingFloodScene");
    }
    public static int GetRightAns(){
        return rightAns;
    }
    public static int GetWrongAns(){
        return wrongAns;
    }
}
