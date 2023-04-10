using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer:MonoBehaviour {
    public float speed = 150f;
    private float X;
    private float Y;
    private bool escapeFlag=false;
    public bool cameraBoardBoy;
    public bool cameraBoardGirl;
    public Transform playerBody;
    float xRotation = 0f;
    Vector3 startLocation;

    void Update() {
        if(cameraBoardBoy){
            GetComponent<Camera>().transform.GetComponent<LookAt>().enabled=true;
            startLocation = transform.localPosition;
            transform.localPosition =  new Vector3(transform.localPosition.x, 1.352f, 0.3f);
            cameraBoardBoy=false;
            GetComponent<Camera>().transform.GetComponent<LookAt>().enabled=false;
        }
        if(cameraBoardGirl){
            GetComponent<Camera>().transform.GetComponent<LookAt>().enabled=true;
            startLocation = transform.localPosition;
            transform.localPosition =  new Vector3(transform.localPosition.x, 1.352f, transform.localPosition.z);
            cameraBoardGirl=false;
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