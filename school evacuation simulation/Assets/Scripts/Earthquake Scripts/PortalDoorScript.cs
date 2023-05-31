using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalDoorScript : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
		    SceneManager.LoadScene(sceneName);
        }
	}
}