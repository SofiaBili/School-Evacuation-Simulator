using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleQuestionCanvas : MonoBehaviour
{
    [SerializeField] GameObject canvasMultiple1;
    [SerializeField] GameObject canvasMultiple2;
    [SerializeField] GameObject canvasTrueFalse;
    [SerializeField] Camera canvasCamera;

    static GameObject currHitbox;
    static bool showCanvas = false;
    static bool closeCanvas = false;
    int randomCanvas=-1;
    public void SetCurrHitbox(GameObject currentHitbox){
        currHitbox = currentHitbox;
    }
    public GameObject GetCurrHitbox(){
        return currHitbox;
    }
    // Start is called before the first frame update
    void Start()
    {
        canvasCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(showCanvas){
            //canvasTrueFalse.SetActive(true);
            randomCanvas = 2;// Random.Range(0, 3);
            Debug.Log(randomCanvas);
            if(randomCanvas==0){
                canvasMultiple1.SetActive(true);
            }else if(randomCanvas==1){
                canvasMultiple2.SetActive(true);
            }else{
                canvasTrueFalse.SetActive(true);
            }
            canvasCamera.enabled = true;
            showCanvas = false;
            
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