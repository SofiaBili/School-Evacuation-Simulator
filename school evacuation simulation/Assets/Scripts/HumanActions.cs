using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanActions : MonoBehaviour
{
    Animator animator;

    private string currentState;
    private bool fireFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!fireFlag){
            ChangeAnimationState("Sitting");
        }else{
            ChangeAnimationState("Idle");
        }
    }

    public void FireDrillAction(){
        fireFlag = true;
    }
    public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            animator.Play(newState);
    }
}
