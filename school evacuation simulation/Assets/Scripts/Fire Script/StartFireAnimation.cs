using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFireAnimation : MonoBehaviour
{
    public GameObject room;
    public Camera camFire;
    public Animator animator;

    public static bool startAnimation = false;
    public static bool destroyAnimation = false;
	void Awake(){
		startAnimation = false;
		destroyAnimation = false;
    }
    void OnDestroy(){
		startAnimation = false;
		destroyAnimation = false;
    }
    // Update is called once per frame
    void Update(){
        if(startAnimation){
			OpenCamera();
		}if(destroyAnimation){
			DeleteThisRoom();
		}
    }
	void OpenCamera(){
		startAnimation = false;
		camFire.targetDisplay = 0;
		animator.enabled = true;
	}
	public void DeleteThisRoom(){
		destroyAnimation = false;
		camFire.targetDisplay = 2;
		Destroy(gameObject);
	}
}
