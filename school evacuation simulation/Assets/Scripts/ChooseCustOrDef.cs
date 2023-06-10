using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseCustOrDef : MonoBehaviour
{
    public void Choose(bool choice){
		MapCreation.ChooseCustomOrDef(choice);
	}
}