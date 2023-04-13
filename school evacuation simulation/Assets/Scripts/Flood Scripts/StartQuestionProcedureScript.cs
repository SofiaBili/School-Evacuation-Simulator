using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestionProcedureScript : MonoBehaviour
{
    [SerializeField] GameObject hexagonHitbox;
    GameObject canvasMultiple1;
    GameObject canvasMultiple2;
    GameObject canvasTrueFalse;
    [SerializeField] Camera cameraAnimation;
    [SerializeField] Animator animatorQuestion;
    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        canvasMultiple1 = GameObject.Find("Multiple Choise Questions Canvas");
        canvasMultiple2 = GameObject.Find("Multiple Cubed Choise Questions Canvas");
        canvasTrueFalse = GameObject.Find("True False Questions Canvas");
        Debug.Log(canvasMultiple1);
    }

    private void OnTriggerEnter(Collider other){
    }
    
    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(Input.GetKeyDown(KeyCode.Q)){
                int randomCanvas = Random.Range(0, 2);
                if(randomCanvas==0)
                    canvasMultiple1.SetActive(true);
                else if(randomCanvas==1)
                    canvasMultiple2.SetActive(true);
                else
                    canvasTrueFalse.SetActive(true);
                cameraAnimation.targetDisplay = 0;
                ChangeAnimationState("ClickPhone");
            }
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
        if(!animatorQuestion.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            animatorQuestion.Play(newState);
    }
}
