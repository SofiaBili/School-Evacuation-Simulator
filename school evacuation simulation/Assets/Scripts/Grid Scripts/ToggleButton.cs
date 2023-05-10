using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
	public GameObject canvas;
	public GameObject otherCanvas0;
	public GameObject otherCanvas1;
	public GameObject otherCanvas2;
	public GameObject otherCanvas3;
	public GameObject otherCanvas4;
	bool state = false;
	public void ToggleCanvas() {
		state = canvas.activeSelf;
        state = !state;
        canvas.SetActive(state);
        otherCanvas0.SetActive(false);
        otherCanvas1.SetActive(false);
        otherCanvas2.SetActive(false);
        otherCanvas3.SetActive(false);
        otherCanvas4.SetActive(false);
    }
	public void CloseAllCanvas() {
		canvas.SetActive(false);
        otherCanvas0.SetActive(false);
        otherCanvas1.SetActive(false);
        otherCanvas2.SetActive(false);
        otherCanvas3.SetActive(false);
        otherCanvas4.SetActive(false);
    }
}