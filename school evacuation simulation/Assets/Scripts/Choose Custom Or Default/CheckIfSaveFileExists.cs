using UnityEngine;
using System.IO;

public class CheckIfSaveFileExists : MonoBehaviour{
	public GameObject makeYourSchoolCanvas;
	public GameObject panelTextNoFile;
	public GameObject panelTextYesFile;
	public GameObject btnTextReturn;
	public GameObject btnTextEdit;
	public bool panelNoFile;
	public bool editFile = false;
	public bool panelYesFile;
	public void Check(){
		if (File.Exists(Application.dataPath + "/save.txt") && !panelYesFile){
			if(panelNoFile && !editFile){
				ChooseCustOrDef.Choose(false);
				SceneManagerScript.StaticStartGame("ChooseEvacuationType");
			}
			else if(panelNoFile && editFile){ 
				EditOrNewFile.ReplaceFile(false);
				SceneManagerScript.StaticStartGame("GridScene");
			}
		}else if(!File.Exists(Application.dataPath + "/save.txt") && panelYesFile){
			StartNewSchoolMap();
		}else{
			makeYourSchoolCanvas.SetActive(true);
			panelTextNoFile.SetActive(panelNoFile);
			btnTextReturn.SetActive(panelNoFile);
			panelTextYesFile.SetActive(panelYesFile);
			btnTextEdit.SetActive(panelYesFile);
		}
	}
	public void StartNewSchoolMap(){
		Debug.Log(EditOrNewFile.replacementOfFile);
		EditOrNewFile.ReplaceFile(true);
		Debug.Log(EditOrNewFile.replacementOfFile);
		SceneManagerScript.StaticStartGame("GridScene");
		
	}
}