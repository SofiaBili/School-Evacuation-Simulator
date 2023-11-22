using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
	public GameObject infoCanvas2;
	public GameObject infoCanvas3;
	public TextMeshProUGUI infoCanvas1Text;
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


	public List<GameObject> chairs;

	public GameObject spawn1, spawn2, spawn3, spawn4;
	GameObject thisPlayer;
	public bool spawn1Free=false, spawn2Free=false, spawn3Free=false, spawn4Free=false;
	public static bool stopMovementWhileWalking = false;
	public static bool finishedQuestions = false;
	void Awake(){
		ResetAll();
	}
	void ResetAll(){
		stopMovement = false;
		worriedTeacher = false;
		startFirstCoroutine = true;
		stopCoroutine = false;
		stopMult3 = true;
		stopTrueFalse = true;
		stopMult4 = true;
		step=-1;
		flag = true;
		stopMovementWhileWalking = false;
		finishedQuestions = false;
		Cursor.lockState=CursorLockMode.None;
		ElevatorTriggerScript.isIn = false;
	}
	void OnDestroy() {
		ResetAll();
		EarthquakeGuideScript.guideIsOver = false;
	}
    void Start(){
		infoCanvas1Text = GetComponent<TextMeshProUGUI>();
		infoCanvas1.SetActive(false);
		hitbox1.SetActive(false);
		hitbox2.SetActive(false);
		hitbox3.SetActive(false);
		hitbox4.SetActive(false);
        earthquakeAnimator = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
			playerFlag = true;
			thisPlayer = GameObject.Find("Player");
			if(startFirstCoroutine)
				StartCoroutine(StartEarthquake());
		}
	}
	
	public IEnumerator StartEarthquake(){
		if(EarthquakeGuideScript.guideIsOver){
			Debug.Log("llllllllllll");
			ElevatorTriggerScript.isIn = true;
			Cursor.lockState=CursorLockMode.Locked;
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
					ShowDesk.stopShowDesk = true;
					Multiple4EarthquakeManager.GetQuestion(3);
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
				case 10:
					mult4Canvas.SetActive(false);
					
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
					trueFalseCanvas.SetActive(true);
					TrueFalseEarthquakeManager.GetQuestion(3);
					break;
				case 11:
					trueFalseCanvas.SetActive(false);
					mult3Canvas.SetActive(true);
					Multiple3EarthquakeManager.GetQuestion(2);
					break;
				case 12:
					mult3Canvas.SetActive(false);
					mult4Canvas.SetActive(true);
					Multiple4EarthquakeManager.GetQuestion(2);
					break;
				case 13:
					mult4Canvas.SetActive(false);
					mult3Canvas.SetActive(true);
					Multiple3EarthquakeManager.GetQuestion(3);
					break;
				case 14:
					infoCanvas2.SetActive(true);
					break;
				case 15:
					infoCanvas2.SetActive(false);
					foreach(GameObject thing in chairs){
						thing.GetComponent<MeshCollider>().enabled = false;
					}
					ReturnPlayer();
					break;
				case 16:
					infoCanvas3.SetActive(true);
					PausePlayer();
					break;
				case 17:
					CloseFlag();
					break;
			}
		}
	}
	public void AddStep(){
		step++;
	}
	
	public void CloseFlag(){
		infoCanvas3.SetActive(false);
		ElevatorTriggerScript.isIn = false;
		PlayerMovement.StartFromFireMovement();
		flag = false;
		stopMovementWhileWalking = false;
		finishedQuestions = true;
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
		flag = true;
		PlayerMovement.StopFromFireMovement();
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
