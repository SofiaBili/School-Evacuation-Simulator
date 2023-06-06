using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFireAnimation : MonoBehaviour
{
    public GameObject room;
    public Camera camFire;
    public Animator animator;

    public static bool startAnimation = false;

    // Update is called once per frame
    void Update(){
        if(startAnimation){
			OpenCamera();
		}
    }
	void OpenCamera(){
		startAnimation = false;
		camFire.targetDisplay = 0;
		animator.enabled = true;
	}
}
