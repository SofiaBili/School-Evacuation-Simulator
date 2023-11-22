using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorButtonsScript : MonoBehaviour
{
	public Button btn1;
	public Button btn2;
	Button button1;
	Button button2;
	bool check = true;

	void Start(){
		button1 = btn1.GetComponent<Button>();
		button1.onClick.AddListener(TaskOnClick1);

		button2 = btn2.GetComponent<Button>();
		button2.onClick.AddListener(TaskOnClick2);

		button1.Select();
	}
	void Update(){
		if(check)
			button1.Select();
		else
			button2.Select();
	}
	public void TaskOnClick1() {
		check = true;
    }
	public void TaskOnClick2() {
		check = false;
    }
}