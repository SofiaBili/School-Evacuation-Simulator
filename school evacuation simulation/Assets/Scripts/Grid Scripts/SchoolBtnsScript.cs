using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolBtnsScript : MonoBehaviour
{
	public Button btn1;
	public Button btn2;
	public Button btn3;
	public Button btn4;
	public Button btn5;
	public Button btn6;
	public Button btn7;
	public Button btn8;
	public Button btn9;
	public Button btn10;
	public Button btn11;
	public Button btn12;
	public Button btn13;
	
	Button button1;
	Button button2;
	Button button3;
	Button button4;
	Button button5;
	Button button6;
	Button button7;
	Button button8;
	Button button9;
	Button button10;
	Button button11;
	Button button12;
	Button button13;
	
	public bool isSecondFloor = false;
	int check = -1;

	void Start(){
		button1 = btn1.GetComponent<Button>();
		button1.onClick.AddListener(TaskOnClick1);

		button2 = btn2.GetComponent<Button>();
		button2.onClick.AddListener(TaskOnClick2);

		button3 = btn3.GetComponent<Button>();
		button3.onClick.AddListener(TaskOnClick3);

		button4 = btn4.GetComponent<Button>();
		button4.onClick.AddListener(TaskOnClick4);
		
		button5 = btn5.GetComponent<Button>();
		button5.onClick.AddListener(TaskOnClick5);

		if(!isSecondFloor){
			button6 = btn6.GetComponent<Button>();
			button6.onClick.AddListener(TaskOnClick6);
			
			button7 = btn7.GetComponent<Button>();
			button7.onClick.AddListener(TaskOnClick7);
		}
		button8 = btn8.GetComponent<Button>();
		button8.onClick.AddListener(TaskOnClick8);
		
		button9 = btn9.GetComponent<Button>();
		button9.onClick.AddListener(TaskOnClick9);

		button10 = btn10.GetComponent<Button>();
		button10.onClick.AddListener(TaskOnClick10);

		button11 = btn11.GetComponent<Button>();
		button11.onClick.AddListener(TaskOnClick11);
		
		button12 = btn12.GetComponent<Button>();
		button12.onClick.AddListener(TaskOnClick12);

		button13 = btn13.GetComponent<Button>();
		button13.onClick.AddListener(TaskOnClick13);

	}
	void Update(){
		switch(check){
			case 1: button1.Select(); break;
			case 2: button2.Select(); break;
			case 3: button3.Select(); break;
			case 4: button4.Select(); break;
			case 5: button5.Select(); break;
			case 6: button6.Select(); break;
			case 7: button7.Select(); break;
			case 8: button8.Select(); break;
			case 9: button9.Select(); break;
			case 10: button10.Select(); break;
			case 11: button11.Select(); break;
			case 12: button12.Select(); break;
			case 13: button13.Select(); break;
		}
	}
	public void TaskOnClick1() {
		check = 1;
    }
	public void TaskOnClick2() {
		check = 2;
    }
	public void TaskOnClick3() {
		check = 3;
    }
	public void TaskOnClick4() {
		check = 4;
    }
	public void TaskOnClick5() {
		check = 5;
    }
	public void TaskOnClick6() {
		check = 6;
    }
	public void TaskOnClick7() {
		check = 7;
    }
	public void TaskOnClick8() {
		check = 8;
    }
	public void TaskOnClick9() {
		check = 9;
    }
	public void TaskOnClick10() {
		check = 10;
    }
	public void TaskOnClick11() {
		check = 11;
    }
	public void TaskOnClick12() {
		check = 12;
    }
	public void TaskOnClick13() {
		check = 13;
    }
}