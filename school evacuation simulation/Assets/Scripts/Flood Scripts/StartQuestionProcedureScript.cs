using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestionProcedureScript : MonoBehaviour
{
    [SerializeField] GameObject hexagonHitbox;
    [SerializeField] Camera cameraAnimation;
    [SerializeField] Animator animatorQuestion;
    [SerializeField] GameObject toggleQuestionCanvasObject;
    static ToggleQuestionCanvas toggleQuestionCanvasScript;
    private static string currentState;
    static bool toggleCanvasFlag = true;
    static bool closeCanvasFlag = true;
    static bool deleteHexagonFlag = false;
    static public StartQuestionProcedureScript instance;
    public string firstCameraAnimationName;
    public string secondCameraAnimationName;

    MapCreation mapCreationScript;
    [SerializeField] GameObject mapCreationObject;
    FillBarScript fillBarScript;

    void Awake(){
        toggleQuestionCanvasScript = toggleQuestionCanvasObject.GetComponent<ToggleQuestionCanvas>();
        fillBarScript = toggleQuestionCanvasObject.transform.Find("Point Level Canvas").GetComponent<FillBarScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        mapCreationScript = transform.parent.parent.parent.gameObject.GetComponent<MapCreation>();
    }

    private void OnTriggerEnter(Collider other){
    }
    
    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(Input.GetKeyDown(KeyCode.Q)){
                //σταματάμε την κίνηση του χρήστη
                toggleQuestionCanvasObject.GetComponent<PlayerMovement>().StopMovement();
                GameObject.Find("Main Camera").GetComponent<RotatePlayer>().enabled = false;
                GameObject.Find("Main Camera").GetComponent<PlayerZoom>().enabled = false;
                Cursor.lockState=CursorLockMode.None;

                cameraAnimation.targetDisplay = 0;
                GameObject.Find("Camera").GetComponent<Camera>().cullingMask |=  (1 << LayerMask.NameToLayer("QuestionCanvas"));
                ChangeAnimationState(firstCameraAnimationName);
                StartCoroutine(ShowCanvas());
            }
        }   
    }
    private IEnumerator ShowCanvas(){
        if(toggleCanvasFlag){
            yield return new WaitForSeconds (1.9f);
            toggleQuestionCanvasScript.EnableRandomCanvas(hexagonHitbox);
            toggleCanvasFlag = false;
            closeCanvasFlag=true;
        }
    }
    private IEnumerator CloseCanvas(bool check){
        if(closeCanvasFlag){
            if(!check)
                yield return new WaitForSeconds (2.2f);
            ChangeAnimationState(secondCameraAnimationName);
            toggleQuestionCanvasScript.CloseSpecificCanvas();
            yield return new WaitForSeconds (1.9f);
            ChangeAnimationState("Idle");
            cameraAnimation.targetDisplay = 2;
            closeCanvasFlag = false;
            toggleCanvasFlag = true;

            if(deleteHexagonFlag){
                mapCreationScript.SetHexagonNumber(mapCreationScript.GetHexagonNumber()-1);
                if(!fillBarScript.ShowWinningCanvas() && mapCreationScript.GetHexagonNumber() == 0){
                    Debug.Log("jjjjjjjjjj");
                    fillBarScript.ShowLosingCanvas();
                }
                yield return new WaitForSeconds (0.01f);
                deleteHexagonFlag = false;
                hexagonHitbox.SetActive(false);
            }
            //επιτρέπουμε την κίνηση του χρήστη πάλι
            toggleQuestionCanvasObject.GetComponent<PlayerMovement>().StartMovement();
            GameObject.Find("Main Camera").GetComponent<RotatePlayer>().enabled = true;
            GameObject.Find("Main Camera").GetComponent<PlayerZoom>().enabled = true;
            Cursor.lockState=CursorLockMode.Locked;
        }
    }
    //when user exits disable canvas and camera animation back
    void OnTriggerExit(Collider other){
        
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
        Debug.Log(mapCreationScript.GetHexagonNumber());
        
        //hexagonHitbox.SetActive(false);
        //hexagonHitbox.enabled = false;
    }
}
