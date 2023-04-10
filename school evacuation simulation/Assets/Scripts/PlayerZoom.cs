using UnityEngine;
using System.Collections;
 
public class PlayerZoom : MonoBehaviour {
 
    public Camera mainCamera ;
        
    void Update () {
        if(Input.GetKey(KeyCode.LeftControl)) {
            if (Input.GetAxis("Mouse ScrollWheel")>0 && mainCamera.fieldOfView > 30 ) // forward
            {
                mainCamera.fieldOfView -= 2;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") <0 && mainCamera.fieldOfView < 55 ) // backwards
            {
                mainCamera.fieldOfView += 2;
            }
        }
        else{
            mainCamera.fieldOfView = 55;
        }
    }
}