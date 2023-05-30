using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    Animator animator;
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }
    void Update(){
        if(EarthquakeClassScript.worriedTeacher){
            ChangeAnimationState("mixamo_com");
        }
    }
    public void ChangeAnimationState(string newState){
        animator.Play(newState);
    }
}