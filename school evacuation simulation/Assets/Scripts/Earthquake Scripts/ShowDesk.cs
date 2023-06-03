using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDesk : MonoBehaviour
{
    [SerializeField] Camera cameraAnimation;
    [SerializeField] GameObject cameraObject;
	GameObject room;
	public static bool startShowDesk = false;
	public static bool stopShowDesk = false;
	public static bool continueQuest = false;

	void Update(){
		if(startShowDesk){
			ChangeCamera();
		}else if(stopShowDesk){
			DestroyRoom();
		}
	}

	public void ChangeCamera(){
		cameraObject.SetActive(true);
		startShowDesk = false;
		cameraAnimation.targetDisplay = 0;
		continueQuest = true;
    }
	public void DestroyRoom(){
		stopShowDesk = false;
        Destroy(room);
		cameraAnimation.GetComponent<Camera>().cullingMask |=  (1 << LayerMask.NameToLayer("QuestionCanvas"));
	}
}
