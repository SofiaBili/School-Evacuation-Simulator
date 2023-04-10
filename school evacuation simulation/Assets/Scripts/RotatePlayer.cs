using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer:MonoBehaviour {
    public float speed = 150f;
    private float X;
    private float Y;
    private bool escapeFlag=false;
    private bool cameraBoard=true;
    public Transform playerBody;
    float xRotation = 0f;
    Vector3 startLocation;

    void Update() {
        if(cameraBoard){
            GetComponent<Camera>().transform.GetComponent<LookAt>().enabled=true;
            startLocation = transform.localPosition;
            transform.localPosition =  new Vector3(transform.localPosition.x, 1.352f, 0.3f);
            cameraBoard=false;
            GetComponent<Camera>().transform.GetComponent<LookAt>().enabled=false;
        }
        if(!escapeFlag){
            Cursor.lockState=CursorLockMode.Locked;
            X = Input.GetAxis("Mouse X") * speed*Time.deltaTime;
            Y = Input.GetAxis("Mouse Y") * speed*Time.deltaTime;
            xRotation -= Y;

            xRotation = Mathf.Clamp(xRotation, -90f, 63f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up*X);
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(!escapeFlag){
                Cursor.lockState=CursorLockMode.None;
                escapeFlag=true;
            }
            else{
                escapeFlag=false;
            }
        }  
    }
}