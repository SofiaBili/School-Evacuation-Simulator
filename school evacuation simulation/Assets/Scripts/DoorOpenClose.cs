using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    DoorOpenClose doorOpenClose;
    [SerializeField] GameObject doorHitbox;
    [SerializeField] Transform door;
    [SerializeField] float doorSpeed = 35f;
    bool flag=false;

    void Awake(){
        doorOpenClose = doorHitbox.GetComponent<DoorOpenClose>();
    }

    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            Debug.Log(door.transform.localRotation.eulerAngles.z);
            if (Input.GetKeyDown("space")){
                flag = true;
            }
        }
    }

    void OnTriggerExit(Collider other){
    }

    void Update(){
        if(flag){
            if(door.transform.localRotation.eulerAngles.z<115){
                door.Rotate(0, 0, (doorSpeed * Time.deltaTime));
            }
        }
    }
}
