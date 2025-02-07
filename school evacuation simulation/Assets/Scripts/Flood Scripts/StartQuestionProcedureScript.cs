using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestionProcedureScript : MonoBehaviour
{
    [SerializeField] GameObject hexagonHitbox;
    [SerializeField] Camera cameraAnimation;
    [SerializeField] Animator animatorQuestion;
    [SerializeField] GameObject toggleQuestionCanvasObject;
    [SerializeField] GameObject pressQCanvas;
    static ToggleQuestionCanvas toggleQuestionCanvasScript;
    private static string currentState;
    static bool toggleCanvasFlag = true;
    static bool closeCanvasFlag = true;
    static bool deleteHexagonFlag = false;
    public string firstCameraAnimationName;
    public string secondCameraAnimationName;

    MapCreation mapCreationScript;
    [SerializeField] GameObject mapCreationObject;
    FillBarScript fillBarScript;
    TimerScript timerScript;
    
    public AudioSource audioData;
    public bool playSound = true;

    bool showQCanvas=true;
    public GameObject userCamera;
    public GameObject playerGirl;
    public GameObject questCamera;
    void Awake(){
        toggleCanvasFlag = true;
        closeCanvasFlag = true;
        deleteHexagonFlag = false;
        playerGirl = GameObject.Find("Player Girl");
        userCamera = playerGirl.transform.Find("Main Camera").gameObject;
        questCamera = playerGirl.transform.Find("Camera").gameObject;
        toggleQuestionCanvasScript = toggleQuestionCanvasObject.GetComponent<ToggleQuestionCanvas>();
        fillBarScript = toggleQuestionCanvasObject.transform.Find("Point Level Canvas").GetComponent<FillBarScript>();
        timerScript = toggleQuestionCanvasObject.transform.Find("Point Level Canvas").GetComponent<TimerScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        mapCreationScript = transform.parent.parent.parent.gameObject.GetComponent<MapCreation>();
        pressQCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other){
    }
    
    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(showQCanvas) pressQCanvas.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Q) && showQCanvas){
                timerScript.StopTimer();
                pressQCanvas.SetActive(false);
                showQCanvas = false;
                //σταματάμε την κίνηση του χρήστη
                toggleQuestionCanvasObject.GetComponent<PlayerMovement>().StopMovement();
                userCamera.GetComponent<RotatePlayer>().enabled = false;
                userCamera.GetComponent<PlayerZoom>().enabled = false;
                Cursor.lockState=CursorLockMode.None;
                cameraAnimation.targetDisplay = 0;
                questCamera.GetComponent<Camera>().cullingMask |=  (1 << LayerMask.NameToLayer("QuestionCanvas"));
                ChangeAnimationState(firstCameraAnimationName);
                StartCoroutine(ShowCanvas());
            }
        }   
    }
    private IEnumerator ShowCanvas(){
        if(toggleCanvasFlag){
            if(playSound) audioData.Play(0);
            yield return new WaitForSeconds (1.9f);
            if(playSound) audioData.Stop();
            questCamera.GetComponent<Camera>().targetDisplay = 0;
            timerScript.StartTimer();
            toggleQuestionCanvasScript.EnableRandomCanvas(hexagonHitbox);
            toggleCanvasFlag = false;
            closeCanvasFlag=true;
        }
    }
    private IEnumerator CloseCanvas(bool check){
        if(closeCanvasFlag){
            timerScript.StopTimer();
            if(!check)
                yield return new WaitForSeconds (2.2f);
            questCamera.GetComponent<Camera>().targetDisplay = 1;
            ChangeAnimationState(secondCameraAnimationName);
            yield return new WaitForSeconds (0.12f);
            if(playSound) audioData.Play(0);
            toggleQuestionCanvasScript.CloseSpecificCanvas();
            yield return new WaitForSeconds (1.9f);
            ChangeAnimationState("Idle");
            cameraAnimation.targetDisplay = 2;
            closeCanvasFlag = false;
            toggleCanvasFlag = true;

            if(deleteHexagonFlag){
                mapCreationScript.SetHexagonNumber(mapCreationScript.GetHexagonNumber()-1);
                if(!fillBarScript.ShowWinningCanvas() && mapCreationScript.GetHexagonNumber() == 0){
                    fillBarScript.ShowLosingCanvas();
                }
                yield return new WaitForSeconds (0.01f);
                deleteHexagonFlag = false;
                hexagonHitbox.SetActive(false);
            }
            if(playSound) audioData.Stop();
            //επιτρέπουμε την κίνηση του χρήστη πάλι
            toggleQuestionCanvasObject.GetComponent<PlayerMovement>().StartMovement();
            userCamera.GetComponent<RotatePlayer>().enabled = true;
            userCamera.GetComponent<PlayerZoom>().enabled = true;
            Cursor.lockState=CursorLockMode.Locked;
            showQCanvas = true;
            
            timerScript.StartTimer();
        }
    }
    //when user exits disable canvas and camera animation back
    void OnTriggerExit(Collider other){
        pressQCanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
    }
    
    public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!animatorQuestion.GetCurrentAnimatorStateInfo(0).IsName(currentState)){
           // Debug.Log(newState);
            animatorQuestion.Play(newState);}
    }
    public void StopAnimationAndCloseCanvas(){
        //CallChangeAnimationState();
        StartCoroutine(CloseCanvas(false));
    }
    public void StopAnimationAndCloseCanvasFromExit(){
        StartCoroutine(CloseCanvas(true));
    }
    public void DeleteHexagon(){
        deleteHexagonFlag = true;
        StopAnimationAndCloseCanvas();
        //Debug.Log(mapCreationScript.GetHexagonNumber());
        
        //hexagonHitbox.SetActive(false);
        //hexagonHitbox.enabled = false;
    }
}
