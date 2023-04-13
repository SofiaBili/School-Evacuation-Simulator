using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleQuestionCanvas : MonoBehaviour
{
    [SerializeField] GameObject canvasMultiple1;
    [SerializeField] GameObject canvasMultiple2;
    [SerializeField] GameObject canvasTrueFalse;
    [SerializeField] Camera canvasCamera;
    static bool showCanvas = false;
    static bool closeCanvas = false;
    int randomCanvas;
    // Start is called before the first frame update
    void Start()
    {
        canvasCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(showCanvas){
            canvasTrueFalse.SetActive(true);
            /*randomCanvas= Random.Range(0, 3);
            if(randomCanvas==0){
                canvasMultiple1.SetActive(true);
            }else if(randomCanvas==1){
                canvasMultiple2.SetActive(true);
            }else{
                canvasTrueFalse.SetActive(true);
            }*/
            canvasCamera.enabled = true;
            showCanvas = false;
            
        }
        if(closeCanvas){
            canvasTrueFalse.SetActive(false);
            /*randomCanvas= Random.Range(0, 3);
            if(randomCanvas==0){
                canvasMultiple1.SetActive(true);
            }else if(randomCanvas==1){
                canvasMultiple2.SetActive(true);
            }else{
                canvasTrueFalse.SetActive(true);
            }*/
            canvasCamera.enabled = false;
            closeCanvas = false;
            
        }
    }
    public void CloseSpecificCanvas(){
        closeCanvas = true;
    }
    public void EnableRandomCanvas(){
        showCanvas = true;
    }
}