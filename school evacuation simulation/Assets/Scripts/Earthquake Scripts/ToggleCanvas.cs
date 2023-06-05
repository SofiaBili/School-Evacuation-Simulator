using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCanvas : MonoBehaviour
{
	public GameObject canvas;
	static bool state = false;
	static GameObject staticCanvas;
	void Start(){
        canvas.SetActive(false);
		staticCanvas = canvas;
	}
	public static void ToggleOneCanvas() {
		state = staticCanvas.activeSelf;
        state = !state;
        staticCanvas.SetActive(state);
    }
}