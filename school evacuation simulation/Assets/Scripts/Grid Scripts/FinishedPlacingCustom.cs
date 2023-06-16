using UnityEngine;
using System.IO;

public class FinishedPlacingCustom : MonoBehaviour{
	public static bool firstFloor = false;
	public static bool secondFloor = false;
	public static void FinishedFirstFloor(){
		firstFloor = true;
	}
	public static void FinishedSecFloor(){
		secondFloor = true;
	}
}