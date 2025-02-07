using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFloor : MonoBehaviour
{   
    [SerializeField] GameObject firstFloor;
    [SerializeField] GameObject secondFloor;
    [SerializeField] GameObject player;
    [SerializeField] Camera mapCamera;
    [SerializeField] Camera miniMapCamera;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(player.transform.position.y>4.0f){
            mapCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("FirstFloor"));
            mapCamera.cullingMask |=  (1 << LayerMask.NameToLayer("SecondFloor"));
            miniMapCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("FirstFloor"));
            miniMapCamera.cullingMask |=  (1 << LayerMask.NameToLayer("SecondFloor"));
        }else{
            mapCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("SecondFloor"));
            mapCamera.cullingMask |=  (1 << LayerMask.NameToLayer("FirstFloor"));
            miniMapCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("SecondFloor"));
            miniMapCamera.cullingMask |=  (1 << LayerMask.NameToLayer("FirstFloor"));
        }
    }
}
