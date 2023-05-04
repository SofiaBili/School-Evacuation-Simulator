using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
	public GameObject canvas;
	bool state = false;
	public void ToggleCanvas() {
        state = !state;
        canvas.SetActive(state);
    }
}