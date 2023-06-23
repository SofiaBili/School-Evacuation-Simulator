using UnityEngine;
using System.IO;

public class EditOrNewFile : MonoBehaviour{
	public static bool replacementOfFile = false;
	void Awake(){
		replacementOfFile = false;
	}
	public static void ReplaceFile(bool replace){
		if (replace){
			replacementOfFile = true;
		}else{
			replacementOfFile =  false;
		}
	}
}