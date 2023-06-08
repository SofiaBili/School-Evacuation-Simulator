using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireClassScript : MonoBehaviour
{
    public Animator fireAnimator;
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
	public GameObject exitCanvas;
	public GameObject putClassmatesInOrderCanvas;
	public GameObject numbersCanvas;

	public AudioSource alarm;
	public static bool startFirstCoroutine = true;
	public static bool stopCoroutine = false;

	public static bool stopMult3 = true;
	public static bool stopTrueFalse = true;
	public static bool stopMult4 = true;
	public static int step=-1;

	public static bool flag = true;
	public bool playerFlag = false;


	public List<GameObject> chairs;

	public GameObject spawn1, spawn2, spawn3, spawn4;
	GameObject thisPlayer;
	public bool spawn1Free=false, spawn2Free=false, spawn3Free=false, spawn4Free=false;

	public bool stopAnimation = false;
	public static bool stopMovementWhileWalking = false;
	public static bool finishedQuestions = false;
    // Start is called before the first frame update
    void Start(){
		infoCanvas.SetActive(false);
		hitbox1.SetActive(false);
		hitbox2.SetActive(false);
		hitbox3.SetActive(false);
		hitbox4.SetActive(false);
    }
    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
			playerFlag = true;
			thisPlayer = GameObject.Find("Player");
			if(startFirstCoroutine)
				StartCoroutine(StartAnimation());
		}
	}
	
	public IEnumerator StartAnimation(){
		if(FireGuideScript.guideIsOver){
			stopMovement = true;
			Cursor.lockState=CursorLockMode.Locked;
			startFirstCoroutine = false;
			StartFireAnimation.startAnimation = true;
			yield return new WaitForSeconds (10f);
			stopAnimation = true;
			StartCoroutine(StartFireDrill());
		}
	}
	public IEnumerator StartFireDrill(){
		if(FireGuideScript.guideIsOver && stopAnimation){
			ElevatorTriggerScript.isIn = true;
			stopMovement = false;
			StartFireAnimation.destroyAnimation = true;
        	yield return new WaitForSeconds (6f);
			worriedTeacher = true;
			alarm.Play(0);
        	yield return new WaitForSeconds (3f);
			stopMovement = true;
			mult3Canvas.SetActive(true);
			Multiple3EarthquakeManager.GetQuestion(0);
			alarm.Stop();
		}
	}
	void Update(){
		if(FireGuideScript.guideIsOver && flag && playerFlag){
			switch(step) {
				case 0:
					mult3Canvas.SetActive(false);
					mult4Canvas.SetActive(true);
					Multiple4EarthquakeManager.GetQuestion(0);
					break;
				case 1:
					mult4Canvas.SetActive(false);
					mult4Canvas.SetActive(true);
					Multiple4EarthquakeManager.GetQuestion(1);
					break;
				case 2:
					mult4Canvas.SetActive(false);
					trueFalseCanvas.SetActive(true);
					TrueFalseEarthquakeManager.GetQuestion(0);
					break;
				case 3:
					trueFalseCanvas.SetActive(false);
					numbersCanvas.SetActive(true);
					break;
				case 4:
					numbersCanvas.SetActive(false);
					trueFalseCanvas.SetActive(true);
					TrueFalseEarthquakeManager.GetQuestion(1);
					break;
				case 5:
					trueFalseCanvas.SetActive(false);
					mult4Canvas.SetActive(true);
					Multiple4EarthquakeManager.GetQuestion(2);
					break;
				case 6:
					mult4Canvas.SetActive(false);
					mult3Canvas.SetActive(true);
					Multiple3EarthquakeManager.GetQuestion(1);
					break;
				case 7:
					mult3Canvas.SetActive(false);
					trueFalseCanvas.SetActive(true);
					TrueFalseEarthquakeManager.GetQuestion(2);
					break;
				case 8:
					trueFalseCanvas.SetActive(false);
					putClassmatesInOrderCanvas.SetActive(true);
					MatchingManager.startFlag = true;
					break;
				case 9:
					putClassmatesInOrderCanvas.SetActive(false);
					infoCanvas.SetActive(true);
					if(spawn1.GetComponent<WhatIsInSpawn>().human!=null){
						spawn1.GetComponent<WhatIsInSpawn>().human.transform.position =  spawn1.GetComponent<WhatIsInSpawn>().hitbox.transform.position;
						spawn1.GetComponent<WhatIsInSpawn>().human.GetComponent<CapsuleCollider>().enabled=true;
						spawn1.GetComponent<WhatIsInSpawn>().human.GetComponent<BoxCollider>().enabled=false;
						spawn1.GetComponent<WhatIsInSpawn>().human.GetComponent<Rigidbody>().isKinematic = true; 
						spawn1.GetComponent<WhatIsInSpawn>().human.GetComponent<HumanActions>().EarthquakeDrillAction();
					}else{
						hitbox1.SetActive(true);
					}
					
					if(spawn2.GetComponent<WhatIsInSpawn>().human!=null){
						spawn2.GetComponent<WhatIsInSpawn>().human.transform.position =  spawn2.GetComponent<WhatIsInSpawn>().hitbox.transform.position;
						spawn2.GetComponent<WhatIsInSpawn>().human.GetComponent<CapsuleCollider>().enabled=true;
						spawn2.GetComponent<WhatIsInSpawn>().human.GetComponent<BoxCollider>().enabled=false;
						spawn2.GetComponent<WhatIsInSpawn>().human.GetComponent<Rigidbody>().isKinematic = true; 
						spawn2.GetComponent<WhatIsInSpawn>().human.GetComponent<HumanActions>().EarthquakeDrillAction();
					}else{
						hitbox2.SetActive(true);
					}
					
					if(spawn3.GetComponent<WhatIsInSpawn>().human!=null){
						spawn3.GetComponent<WhatIsInSpawn>().human.transform.position =  spawn3.GetComponent<WhatIsInSpawn>().hitbox.transform.position;
						spawn3.GetComponent<WhatIsInSpawn>().human.GetComponent<CapsuleCollider>().enabled=true;
						spawn3.GetComponent<WhatIsInSpawn>().human.GetComponent<BoxCollider>().enabled=false;
						spawn3.GetComponent<WhatIsInSpawn>().human.GetComponent<Rigidbody>().isKinematic = true; 
						spawn3.GetComponent<WhatIsInSpawn>().human.GetComponent<HumanActions>().EarthquakeDrillAction();
					}else{
						hitbox3.SetActive(true);
					}
					
					if(spawn4.GetComponent<WhatIsInSpawn>().human!=null){
						spawn4.GetComponent<WhatIsInSpawn>().human.transform.position =  spawn4.GetComponent<WhatIsInSpawn>().hitbox.transform.position;
						spawn4.GetComponent<WhatIsInSpawn>().human.GetComponent<CapsuleCollider>().enabled=true;
						spawn4.GetComponent<WhatIsInSpawn>().human.GetComponent<BoxCollider>().enabled=false;
						spawn4.GetComponent<WhatIsInSpawn>().human.GetComponent<Rigidbody>().isKinematic = true; 
						spawn4.GetComponent<WhatIsInSpawn>().human.GetComponent<HumanActions>().EarthquakeDrillAction();
					}else{
						hitbox4.SetActive(true);
					}
					foreach(GameObject thing in chairs){
						thing.GetComponent<MeshCollider>().enabled = false;
					}
					break;
				case 10:
					infoCanvas.SetActive(false);
					foreach(GameObject thing in chairs){
						thing.GetComponent<MeshCollider>().enabled = false;
					}
					ReturnPlayer();
					break;
				case 11:
					exitCanvas.SetActive(true);
					PausePlayer();
					break;
				case 12: 
					CloseFlag();
					exitCanvas.SetActive(false);
					finishedQuestions = true;
					break;
			}
		}
	}
	public void AddStep(){
		step++;
	}
	public void CloseFlag(){
		ElevatorTriggerScript.isIn = false;
		PlayerMovement.StartFromFireMovement();
		flag = false;
		stopMovementWhileWalking = false;
	}
	public static void LeaveRoomInfo(){
		flag = true;
		stopMovementWhileWalking = true;
		step++;
	}
	public void ReturnPlayer(){
		flag = false;
		stopMovement=false;
		thisPlayer.transform.localPosition =  thisPlayer.transform.localPosition + new Vector3(0, 0, -0.3f);
		thisPlayer.GetComponent<CharacterController>().enabled = true;
		thisPlayer.GetComponent<BoxCollider>().enabled=false;
		thisPlayer.GetComponent<HumanActions>().enabled = false;
		thisPlayer.GetComponent<CapsuleCollider>().enabled=true;
		thisPlayer.GetComponent<PlayerMovement>().enabled = true;
		Cursor.lockState=CursorLockMode.Locked;

	}
	public void PausePlayer(){
		PlayerMovement.StopFromFireMovement();
	}
	public static void NextMult3QuestionAndAnimation(int i){
		stopCoroutine = true;
		stopMult3 = false;
		stopTrueFalse = true;
		stopMult4 = false;
	}
	
	public static void NextTrueFalseQuestionAndAnimation(int i){
		stopCoroutine = true;
		stopMult3 = false;
		stopTrueFalse = true;
		stopMult4 = false;
	}
	public static void NextMult4QuestionAndAnimation(int i){
		stopCoroutine = true;
		stopMult3 = true;
		stopTrueFalse = true;
		stopMult4 = true;
	}
	public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!fireAnimator.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            fireAnimator.Play(newState);
    }
}
