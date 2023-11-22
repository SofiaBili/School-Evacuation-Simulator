using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorTriggerScript : MonoBehaviour
{
    public GameObject infoCanvas;
    public static bool isIn = false;
    private void OnTriggerEnter(Collider other){
        if(other.GetType().ToString().Equals("UnityEngine.CapsuleCollider") && other.gameObject.CompareTag("Player") && !isIn){
			isIn = true;
		    infoCanvas.SetActive(true);
			FireClassScript.stopMovementWhileWalking=true;
			EarthquakeClassScript.stopMovementWhileWalking=true;
			PlayerMovement.StopFromFireMovement();
			FireClassScript.finishedQuestions=false;
			EarthquakeClassScript.finishedQuestions=false;
        }
	}
	void OnTriggerExit(Collider other){
        if(other.GetType().ToString().Equals("UnityEngine.CapsuleCollider") && other.gameObject.CompareTag("Player")){
			Debug.Log("ooooooooooooooo");
			isIn = false;
		}
    }
	public void ReturnElevator(){
		PlayerMovement.StartFromFireMovement();
		FireClassScript.stopMovementWhileWalking=false;
		EarthquakeClassScript.stopMovementWhileWalking=false;
		FireClassScript.finishedQuestions=true;
		EarthquakeClassScript.finishedQuestions=true;
	}
}