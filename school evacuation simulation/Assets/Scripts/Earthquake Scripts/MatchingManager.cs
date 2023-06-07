using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MatchingManager : MonoBehaviour
{
	public Button btn;
	public TMP_InputField  inputA;
	public TMP_InputField  inputB;
	public TMP_InputField  inputC; 
	public TMP_InputField  inputD;
	public int countRight = 0;

	public Button btnA;
	public GameObject spawnA;
	public GameObject girlImageA;
	public GameObject boyImageA;
	public Button btnB;
	public GameObject spawnB;
	public GameObject girlImageB;
	public GameObject boyImageB;
	public Button btnC;
	public GameObject spawnC;
	public GameObject girlImageC;
	public GameObject boyImageC;
	public Button btnD;
	public GameObject spawnD;
	public GameObject girlImageD;
	public GameObject boyImageD;
	public static bool startFlag=false;
	public bool isEarth = true;
	
	public string correctA = "3", correctB = "1", correctC = "4", correctD = "2";

	public AudioSource corrSound, wrongSound;
	
	void Update(){
		if(startFlag) StartImageSpawn();
	}
    public void StartImageSpawn(){
		startFlag=false;
		if(spawnA.GetComponent<WhatIsInSpawn>().isGirl){
			girlImageA.SetActive(true);
		}else{
			boyImageA.SetActive(true);
		}
		if(spawnB.GetComponent<WhatIsInSpawn>().isGirl){
			girlImageB.SetActive(true);
		}else{
			boyImageB.SetActive(true);
		}
		if(spawnC.GetComponent<WhatIsInSpawn>().isGirl){
			girlImageC.SetActive(true);
		}else{
			boyImageC.SetActive(true);
		}
		if(spawnD.GetComponent<WhatIsInSpawn>().isGirl){
			girlImageD.SetActive(true);
		}else{
			boyImageD.SetActive(true);
		}
	}
	public void CheckAns(){
		countRight = 0;
		if(inputA.text != correctA){
			inputA.image.color = Color.red;
			countRight=0;
			StartCoroutine(WrongChoices());
		}else{
			inputA.image.color = Color.green;
			countRight++;
		}
		if(inputB.text != correctB){
			inputB.image.color = Color.red;
			countRight=0;
			StartCoroutine(WrongChoices());
		}else{
			inputB.image.color = Color.green;
			countRight++;
		}
		if(inputC.text != correctC){
			inputC.image.color = Color.red;
			countRight=0;
			StartCoroutine(WrongChoices());
		}else{
			inputC.image.color = Color.green;
			countRight++;
		}
		if(inputD.text != correctD){
			inputD.image.color = Color.red;
			countRight=0;
			StartCoroutine(WrongChoices());
		}else{
			inputD.image.color = Color.green;
			countRight++;
		}
		if(countRight==4){
			StartCoroutine(PlaySound());
		}
	}
	private IEnumerator WrongChoices(){
		HealthPlayer.removing = true;
		wrongSound.Play();
		yield return new WaitForSeconds (3f);
		wrongSound.Stop();
	}
	private IEnumerator PlaySound(){
		GetComponent<CanvasGroup>().interactable = false;
		HealthPlayer.RightAnswer();
		corrSound.Play();
		yield return new WaitForSeconds (3f);
		corrSound.Stop();
		if(isEarth) EarthquakeClassScript.step++;
		else FireClassScript.step++;
	}
}
