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
	public GameObject chooseDeskPosCanvas;
	public GameObject infoCanvas;
	public GameObject infoCanvas1;
	public GameObject putClassmatesInOrderCanvas;

	public AudioSource alarm;
	public static bool startFirstCoroutine = true;
	public static bool stopCoroutine = false;

	public static bool stopMult3 = true;
	public static bool stopTrueFalse = true;
	public static bool stopMult4 = true;
	public static int step=-1;

	public static bool flag = true;
	public bool playerFlag = false;

    // Start is called before the first frame update
    void Start(){
        earthquakeAnimator = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
			playerFlag = true;
			if(startFirstCoroutine)
				StartCoroutine(StartEarthquake());
		}
	}
	public IEnumerator StartEarthquake(){
		if(EarthquakeGuideScript.guideIsOver){
			startFirstCoroutine = false;
        	yield return new WaitForSeconds (4f);
			ChangeAnimationState("earthquake");
			worriedTeacher = true;
			alarm.Play(0);
        	yield return new WaitForSeconds (3f);
			alarm.Stop();
			dustParticles.SetActive(true);
        	yield return new WaitForSeconds (1f);
			stopMovement = true;
			mult3Canvas.SetActive(true);
			Multiple3EarthquakeManager.GetQuestion(0);
		}
	}
	void Update(){
		//Debug.Log(flag);
		if(EarthquakeGuideScript.guideIsOver && flag && playerFlag){
			switch(step) {
				case 0:
					StopCoroutine(StartEarthquake());
					mult3Canvas.SetActive(false);
					chooseDeskPosCanvas.SetActive(true);
					TrueFalseEarthquakeManager.GetQuestion(0);
					break;
				case 1:
					chooseDeskPosCanvas.SetActive(false);
					trueFalseCanvas.SetActive(true);
					TrueFalseEarthquakeManager.GetQuestion(1);
					break;
				case 2:
					trueFalseCanvas.SetActive(false);
					ShowDesk.startShowDesk = true;
					if(ShowDesk.continueQuest){
						mult3Canvas.SetActive(true);
						Multiple3EarthquakeManager.GetQuestion(1);
						ShowDesk.continueQuest = false;
					}
					break;
				case 3:
					mult3Canvas.SetActive(false);
					infoCanvas.SetActive(true);
					break;
				case 4:
					infoCanvas.SetActive(false);
					mult4Canvas.SetActive(true);
					Multiple4EarthquakeManager.GetQuestion(0);
					break;
				case 5:
					mult4Canvas.SetActive(false);
					infoCanvas1.SetActive(true);
					break;
				case 6:
					infoCanvas1.SetActive(false);
					trueFalseCanvas.SetActive(true);
					TrueFalseEarthquakeManager.GetQuestion(2);
					break;
				case 7:
					trueFalseCanvas.SetActive(false);
					mult4Canvas.SetActive(true);
					Multiple4EarthquakeManager.GetQuestion(3);
					ShowDesk.stopShowDesk = true;
					break;
				case 8:
					mult4Canvas.SetActive(false);
					putClassmatesInOrderCanvas.SetActive(true);
					MatchingManager.startFlag = true;
					break;
				case 9:
					putClassmatesInOrderCanvas.SetActive(false);
					mult4Canvas.SetActive(true);
					Multiple4EarthquakeManager.GetQuestion(1);
					break;
			}
		}
	}
	public void AddStep(){
		step++;
	}
	public static void NextMult3QuestionAndAnimation(int i){
		stopCoroutine = true;
		//Multiple3EarthquakeManager.GetQuestion(i);
		stopMult3 = false;
		stopTrueFalse = true;
		stopMult4 = false;
	}
	
	public static void NextTrueFalseQuestionAndAnimation(int i){
		stopCoroutine = true;
		//Multiple3EarthquakeManager.GetQuestion(i);
		stopMult3 = false;
		stopTrueFalse = true;
		stopMult4 = false;
	}
	public static void NextMult4QuestionAndAnimation(int i){
		stopCoroutine = true;
		//Multiple3EarthquakeManager.GetQuestion(i);
		stopMult3 = true;
		stopTrueFalse = true;
		stopMult4 = true;
	}
	public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!earthquakeAnimator.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            earthquakeAnimator.Play(newState);
    }
}
