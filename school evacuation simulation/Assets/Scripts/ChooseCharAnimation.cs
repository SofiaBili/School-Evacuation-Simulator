using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharAnimation : MonoBehaviour
{
    Animator animator;

    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnimationState("Wave");
    }

    public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            animator.Play(newState);
    }
}
