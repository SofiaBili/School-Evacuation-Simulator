using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutPhotoInBtn : MonoBehaviour
{
	public GameObject spawn;
	public Image girlImage;
	public Image boyImage;

	void Start(){
		if(spawn.GetComponent<WhatIsInSpawn>().isGirl){
			girlImage.enabled = true;
		}else{
			boyImage.enabled = true;
		}
	}
}