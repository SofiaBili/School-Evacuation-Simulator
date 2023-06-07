using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer:MonoBehaviour {
    public float speed = 150f;
    private float X;
    private float Y;
    public static bool escapeFlag=false;
    public bool cameraBoardBoy;
    public bool cameraBoardGirl;
    public Transform playerBody;
    float xRotation = 0f;
    public float zRotation = 63f;
    Vector3 startLocation;
    public bool isEarthquake = false;
    public bool isFire = false;
    void Update() {
        if(isEarthquake || EarthquakeClassScript.stopMovement || isFire || FireClassScript.stopMovement){
            if(EarthquakeGuideScript.guideIsOver) isEarthquake = false;
            if(FireGuideScript.guideIsOver) isFire = false;
            if(EarthquakeClassScript.stopMovement || FireClassScript.stopMovement) Cursor.lockState=CursorLockMode.None;
        }else{
            if(!escapeFlag){
                Cursor.lockState=CursorLockMode.Locked;
                X = Input.GetAxis("Mouse X") * speed*Time.deltaTime;
                Y = Input.GetAxis("Mouse Y") * speed*Time.deltaTime;
                xRotation -= Y;

                xRotation = Mathf.Clamp(xRotation, -90f, zRotation);

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
}