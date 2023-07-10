using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleQuestionCanvas : MonoBehaviour
{
    [SerializeField] GameObject canvasMultiple1;
    [SerializeField] GameObject canvasMultiple2;
    [SerializeField] GameObject canvasTrueFalse;
    [SerializeField] GameObject miniMapCanvas;
    [SerializeField] Camera canvasCamera;

    static GameObject currHitbox;
    static bool showCanvas = false;
    static bool closeCanvas = false;
    int randomCanvas=-1;
    //int previousRandom=-1;
    void Awake(){
        showCanvas = false;
        closeCanvas = false;
    }
    public void SetCurrHitbox(GameObject currentHitbox){
        currHitbox = currentHitbox;
    }
    public GameObject GetCurrHitbox(){
        return currHitbox;
    }
    // Start is called before the first frame update
    void Start(){
        showCanvas = false;
        closeCanvas = false;
        canvasCamera.enabled = false;
    }
    void OnDestroy(){
        showCanvas = false;
        closeCanvas = false;
    }
    // Update is called once per frame
    void Update(){
        if(showCanvas){
            //canvasTrueFalse.SetActive(true);
            randomCanvas = Random.Range(0, 3);
            /*while(previousRandom == randomCanvas){
                randomCanvas = Random.Range(0, 3);
            }
            previousRandom = randomCanvas;*/
            Debug.Log("CANVAS" + randomCanvas);
            if(randomCanvas==0){
                if(Multiple3ChoiceManager.UnansweredQuestionsCount()){
                    canvasMultiple1.SetActive(true);
                    miniMapCanvas.SetActive(false);
                    canvasCamera.enabled = true;
                    showCanvas = false;
                }
            }else if(randomCanvas==1){
                if(Multiple4ChoiceManager.UnansweredQuestionsCount()){
                    canvasMultiple2.SetActive(true);
                    miniMapCanvas.SetActive(false);
                    canvasCamera.enabled = true;
                    showCanvas = false;
                }
            }else{
                if(TrueFalseManager.UnansweredQuestionsCount1()){
                    canvasTrueFalse.SetActive(true);
                    miniMapCanvas.SetActive(false);
                    canvasCamera.enabled = true;
                    showCanvas = false;
                }
            }
            /*if(TrueFalseManager.UnansweredQuestionsCount1() || Multiple3ChoiceManager.UnansweredQuestionsCount() || Multiple4ChoiceManager.UnansweredQuestionsCount()){
                miniMapCanvas.SetActive(false);
                canvasCamera.enabled = true;
                showCanvas = false;
            }*/
        }
        if(closeCanvas){
            //canvasTrueFalse.SetActive(false);
            if(randomCanvas==0){
                canvasMultiple1.SetActive(false);
            }else if(randomCanvas==1){
                canvasMultiple2.SetActive(false);
            }else{
                canvasTrueFalse.SetActive(false);
            }
            canvasCamera.enabled = false;
            miniMapCanvas.SetActive(true);
            closeCanvas = false;
            
        }
        //Debug.Log(currHitbox);
    }
    public void CloseSpecificCanvas(){
        closeCanvas = true;
    }
    public void EnableRandomCanvas(GameObject currentHitbox){
        showCanvas = true;
        SetCurrHitbox(currentHitbox);
        //currHitbox = currentHitbox;
        //Debug.Log(currentHitbox);
    }
}