using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestion : MonoBehaviour
{
    [SerializeField] GameObject hexagonHitbox;
    [SerializeField] GameObject canvasMultiple1;
    [SerializeField] GameObject canvasMultiple2;
    [SerializeField] GameObject canvasTrueFalse;
    [SerializeField] GameObject miniCameraCanvas;
    [SerializeField] Camera cameraRoom;
    [SerializeField] Camera cameraAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(Input.GetKeyDown(KeyCode.Q)){
                randomCanvas = Random.Range(0, 2);
                miniCameraCanvas.SetActive(false);
                if(randomCanvas==0)
                    canvasMultiple1.SetActive(true);
                else if(randomCanvas==1)
                    canvasMultiple2.SetActive(true);
                else
                    canvasTrueFalse.SetActive(true);
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
}
