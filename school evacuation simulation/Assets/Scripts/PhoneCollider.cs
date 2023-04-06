using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCollider : MonoBehaviour
{   
    [SerializeField] GameObject phoneHitbox;
    [SerializeField] Camera cameraRoom;
    [SerializeField] Camera cameraAnimation;
    [SerializeField] Animator animatorPhone;
    bool flag=false;

    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        //animatorPhone = GetComponent<Animator>();
    }


    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if (Input.GetKeyDown(KeyCode.T)){
                flag = true;
            }
        }
    }

    void OnTriggerExit(Collider other){
    }

    void Update(){
        if(flag){
            cameraAnimation.targetDisplay = 0;
            //Cursor.lockState=CursorLockMode.None;
            //cameraAnimation.targetDisplay = 3;
            //cameraRoom.targetDisplay = 0;
            ChangeAnimationState("ClickPhone");
            //Time.timeScale = 0;
        }
    }

    public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!animatorPhone.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            animatorPhone.Play(newState);
    }
}
