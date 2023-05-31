using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeClassScript : MonoBehaviour
{
    public Animator earthquakeAnimator;
	public GameObject hitbox1, hitbox2, hitbox3, hitbox4;
	public GameObject floorHitBox;
	public GameObject dustParticles;
	public static bool worriedTeacher = false;
    private string currentState;
	public static bool stopMovement = false;

	public GameObject trueFalseCanvas;
	public GameObject mult3Canvas;
	public GameObject mult4Canvas;

	public AudioSource alarm;
    // Start is called before the first frame update
    void Start(){
        earthquakeAnimator = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
			StartCoroutine(StartEarthquake());
		}
	}
	public IEnumerator StartEarthquake(){
		if(EarthquakeGuideScript.guideIsOver){
        	yield return new WaitForSeconds (10f);
			ChangeAnimationState("earthquake");
			worriedTeacher = true;
			alarm.Play(0);
        	yield return new WaitForSeconds (5f);
			alarm.Stop();
			dustParticles.SetActive(true);
        	yield return new WaitForSeconds (1f);
			stopMovement = true;
			//Time.timeScale = 0;
			//RotatePlayer.escapeFlag = true;
			mult3Canvas.SetActive(true);
			Multiple3EarthquakeManager.GetQuestion(0);
			/*if(Multiple3EarthquakeManager.IsAnswered()){	
				Multiple3EarthquakeManager.GetQuestion(1);
			}*/
		}
	}
	public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!earthquakeAnimator.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            earthquakeAnimator.Play(newState);
    }
}
