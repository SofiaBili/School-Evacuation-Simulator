using UnityEngine;
using System.IO;

public class CompleteBtnMap : MonoBehaviour{
    public PlacementSystem placement1;
    public PlacementSystem placement2;

    public void Completion(){
		if(File.Exists(Application.dataPath + "/save.txt")){
            File.Delete (Application.dataPath + "/save.txt");
        }
		placement1.CompleteMap(0);
		placement2.CompleteMap(1);
	}
}