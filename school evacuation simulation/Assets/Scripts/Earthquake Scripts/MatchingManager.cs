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
	void Update(){
		if(startFlag) StartImageSpawn();
	}
    public void StartImageSpawn(){
		startFlag=false;
		Debug.Log("aaaaaaaaaaaaaaaa"+spawnA.GetComponent<WhatIsInSpawn>().isGirl);
		Debug.Log("aaaaaaaaaaaaaaaa"+spawnB.GetComponent<WhatIsInSpawn>().isGirl);
		Debug.Log("aaaaaaaaaaaaaaaa"+spawnC.GetComponent<WhatIsInSpawn>().isGirl);
		Debug.Log("aaaaaaaaaaaaaaaa"+spawnD.GetComponent<WhatIsInSpawn>().isGirl);
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
		if(inputA.text != "3"){
			inputA.image.color = Color.red;
			countRight=0;
		}else{
			inputA.image.color = Color.green;
			countRight++;
		}
		if(inputB.text != "1"){
			inputB.image.color = Color.red;
			countRight=0;
		}else{
			inputB.image.color = Color.green;
			countRight++;
		}
		if(inputC.text != "4"){
			inputC.image.color = Color.red;
			countRight=0;
		}else{
			inputC.image.color = Color.green;
			countRight++;
		}
		if(inputD.text != "2"){
			inputD.image.color = Color.red;
			countRight=0;
		}else{
			inputD.image.color = Color.green;
			countRight++;
		}
		if(countRight==4){
			EarthquakeClassScript.step++;
		}
	}
}
