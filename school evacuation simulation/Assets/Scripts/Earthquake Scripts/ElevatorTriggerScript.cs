using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorTriggerScript : MonoBehaviour
{
    public GameObject infoCanvas;
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
		    infoCanvas.SetActive(true);
			EarthquakeClassScript.stopMovement = true;
			FireClassScript.stopMovement = true;
        }
	}

	public void ReturnElevator(){
		EarthquakeClassScript.stopMovement = false;
		FireClassScript.stopMovement = true;
	}
}