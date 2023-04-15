using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestionProcedureScript : MonoBehaviour
{
    [SerializeField] GameObject hexagonHitbox;
    [SerializeField] Camera cameraAnimation;
    [SerializeField] Animator animatorQuestion;
    private string currentState;
    ToggleQuestionCanvas toggleQuestionCanvasScript;
    [SerializeField] GameObject toggleQuestionCanvasObject;
    bool toggleCanvasFlag = true;
    bool closeCanvasFlag = true;
    bool isCanvasOpen = false;
    void Awake(){
        toggleQuestionCanvasScript = toggleQuestionCanvasObject.GetComponent<ToggleQuestionCanvas>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other){
    }
    
    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(Input.GetKeyDown(KeyCode.Q)){
                isCanvasOpen=true;
                cameraAnimation.targetDisplay = 0;
                ChangeAnimationState("LookAtBoard");
                StartCoroutine(ShowCanvas());
            }
        }   
    }
    private IEnumerator ShowCanvas(){
        if(toggleCanvasFlag){
            yield return new WaitForSeconds (1.9f);
            toggleQuestionCanvasScript.EnableRandomCanvas();
            toggleCanvasFlag = false;
            closeCanvasFlag=true;
        }
    }
    private IEnumerator CloseCanvas(){
        if(closeCanvasFlag){
            yield return new WaitForSeconds (0.1f);
            
            toggleQuestionCanvasScript.CloseSpecificCanvas();
            yield return new WaitForSeconds (1.9f);
            ChangeAnimationState("Idle");
            cameraAnimation.targetDisplay = 2;
            closeCanvasFlag = false;
            toggleCanvasFlag = true;
        }
    }
    //when user exits disable canvas and camera animation back
    void OnTriggerExit(Collider other){
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B) && isCanvasOpen){
            ChangeAnimationState("ReturnToPlayerCamera");
            StartCoroutine(CloseCanvas());
            isCanvasOpen=false;
        }
    }
    
    public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!animatorQuestion.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            animatorQuestion.Play(newState);
    }
}
