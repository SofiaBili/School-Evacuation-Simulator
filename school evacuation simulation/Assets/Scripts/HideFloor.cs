using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFloor : MonoBehaviour
{   
    [SerializeField] GameObject firstFloor;
    [SerializeField] GameObject secondFloor;
    [SerializeField] GameObject player;
    [SerializeField] Camera mapCamera;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(player.transform.position.y>4.0f){
            //firstFloor.SetActive(false);
            //secondFloor.SetActive(true);
            mapCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("FirstFloor"));
            mapCamera.cullingMask |=  (1 << LayerMask.NameToLayer("SecondFloor"));
        }else{
            //firstFloor.SetActive(true
            mapCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("SecondFloor"));
            mapCamera.cullingMask |=  (1 << LayerMask.NameToLayer("FirstFloor"));
            //secondFloor.SetActive(false);
        }
    }
}
