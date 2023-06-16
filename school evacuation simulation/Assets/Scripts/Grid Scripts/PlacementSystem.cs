using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
	[SerializeField] private Grid grid;

	[SerializeField] private ObjectsDatabase database;
	
	[SerializeField] private PreviewSystem preview;
	//trigger grid visualization
	[SerializeField] private GameObject gridVisualization;

    private GridData floorData, furnitureData;
	private Vector3Int lastDetectedPosition = Vector3Int.zero;

	[SerializeField] private ObjectPlacer objectPlacer;

	[SerializeField] private bool isSecondFloor = false;
	[SerializeField] private GameObject secondPlane;
	[SerializeField] private GameObject firstPlane;

	IBuildingState buildingState;

	GameObject parentObj;
	int ID;
	int rotation;

	public static string[,,] schoolMapArray = new string[11,11,2];//10x10x2
    string[] splitAtHashtag;

	private void Start(){
		Debug.Log(EditOrNewFile.replacementOfFile);
		StopPlacement();
		floorData = new GridData();
		furnitureData = new GridData();
		if(EditOrNewFile.replacementOfFile){
			if(File.Exists(Application.dataPath + "/save.txt")){
				File.Delete (Application.dataPath + "/save.txt");
			}
		}else{
			if(!FinishedPlacingCustom.firstFloor) LoadFile();
		}
		if(isSecondFloor) secondPlane.SetActive(false);
	}
	public void SplitBtnParameter(string par){
		string[] splitPar = par.Split('/');
		ID = int.Parse(splitPar[0]);
		parentObj = GameObject.Find(splitPar[1]);
	}
	public void StartPlacement(string IdAndFloor){
		StopPlacement();
		SplitBtnParameter(IdAndFloor);
		gridVisualization.SetActive(true);
		buildingState = new PlacementState(ID, grid, preview, database, floorData, furnitureData, objectPlacer, parentObj);
		//buildingState.parentObj = parObj;
		inputManager.OnClicked += PlaceStructure;
		inputManager.OnExit += StopPlacement;
	}
	public void StartRemoving(){
		StopPlacement();
		gridVisualization.SetActive(true);
		buildingState = new RemovingState(grid, preview, floorData, furnitureData, objectPlacer);
		inputManager.OnClicked += PlaceStructure;
		inputManager.OnExit += StopPlacement;
	}
	public void CompleteMap(int floor){
		StopPlacement();
		gridVisualization.SetActive(true);
		CompleteState(floor);
		inputManager.OnExit += StopPlacement;
	}
	
    public void CompleteState(int floor)
    {
		Debug.Log(floor);
       	GridData selectedData = furnitureData;
		if(selectedData!=null)
        	selectedData.CompeleteMap(objectPlacer, floor);
    }
	public void StartRotating(){
		StopPlacement();
		gridVisualization.SetActive(true);
		buildingState = new RotatingState(grid, preview, floorData, furnitureData, objectPlacer);
		inputManager.OnClicked += PlaceStructure;
		inputManager.OnExit += StopPlacement;
	}
	public void PlaceStructure(){
			if(inputManager.IsPointerOverUI()){
				return;
			}
			Vector3 mousePosition = inputManager.GetSelectedMapPosition();
			Vector3Int gridPosition = grid.WorldToCell(mousePosition);
			buildingState.OnAction(gridPosition);
	}
	public void StopPlacement(){
		if(buildingState == null)
			return;
		gridVisualization.SetActive(false);
		buildingState.EndState();
		inputManager.OnClicked -= PlaceStructure;
		inputManager.OnExit -= StopPlacement;
		lastDetectedPosition = Vector3Int.zero;
		buildingState = null;//to check in update
	}
	
    private void Update(){
			if(buildingState == null)
				return;
			Vector3 mousePosition = inputManager.GetSelectedMapPosition();
			Vector3Int gridPosition = grid.WorldToCell(mousePosition);
			if(lastDetectedPosition != gridPosition){
				buildingState.UpdateState(gridPosition);
				lastDetectedPosition = gridPosition;
			}
	}
	public void SplitBtn3Parameter(string par){
		string[] splitPar = par.Split('/');
		ID = int.Parse(splitPar[0]);
		rotation = int.Parse(splitPar[1]);
		Debug.Log(rotation);
		if(int.Parse(splitPar[2]) == 0)
			parentObj = firstPlane;
		else 
			parentObj = secondPlane;
	}
	private void LoadFile(){
		Vector3Int filePos = Vector3Int.zero;
		Vector3Int gridPosition;
        int x=0, y=0, k=0, l=0;
		int rotationTimes;
        string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
        splitAtHashtag = saveString.Split(char.Parse("#"));
		string[] splitAtSlash;
        Debug.Log(splitAtHashtag.Length-1);
        for(int i=0; i<splitAtHashtag.Length-1; i++){//-1 because last # is empty
			Debug.Log(isSecondFloor);
			Debug.Log(int.Parse(splitAtHashtag[i].Split(char.Parse("/"))[2]));
            if(int.Parse(splitAtHashtag[i].Split(char.Parse("/"))[2]) == 0 && !isSecondFloor){
			Debug.Log("sssssssssssssssssss");
				rotationTimes = 0;
				rotation = 0;
                schoolMapArray[x,y,0] = splitAtHashtag[i];
        		SplitBtn3Parameter(schoolMapArray[x,y,0]);
				if(ID > -1){
					buildingState = new PlacementState(ID, grid, preview, database, floorData, furnitureData, objectPlacer, parentObj);
					buildingState.EndState();
					gridPosition = new Vector3Int(x-5,0,y-5);
					buildingState.OnLoad(gridPosition);
					if(ID!=1 && ID!=2 && ID!=3 && ID!=4 && ID!=5 && ID!=10 && ID!=11 && ID!=12){
						Debug.Log(ID);
						if(rotation == 90) rotationTimes = 1;
						if(rotation == 180) rotationTimes = 2;
						if(rotation == 270) rotationTimes = 3;
						for(int count = 0; count<rotationTimes; count++){
							buildingState = new RotatingState(grid, preview, floorData, furnitureData, objectPlacer);	
							buildingState.OnLoad(gridPosition);
						}
					}
				}
                if(y<9){
                    y++;
                }else{
                    x++; y=0;
                }
            }
			if(int.Parse(splitAtHashtag[i].Split(char.Parse("/"))[2]) == 1 && isSecondFloor){
                rotationTimes = 0;
				rotation = 0;
                schoolMapArray[k,l,1] = splitAtHashtag[i];
        		SplitBtn3Parameter(schoolMapArray[k,l,1]);
				if(ID > -1){
					Debug.Log(parentObj);
					buildingState = new PlacementState(ID, grid, preview, database, floorData, furnitureData, objectPlacer, parentObj);
					buildingState.EndState();
					gridPosition = new Vector3Int(k-5,0,l-5);
					buildingState.OnLoad(gridPosition);
					if(ID!=1 && ID!=2 && ID!=3 && ID!=4 && ID!=5 && ID!=10 && ID!=11 && ID!=12){
						Debug.Log(ID);
						if(rotation == 90) rotationTimes = 1;
						if(rotation == 180) rotationTimes = 2;
						if(rotation == 270) rotationTimes = 3;
						for(int count = 0; count<rotationTimes; count++){
							buildingState = new RotatingState(grid, preview, floorData, furnitureData, objectPlacer);	
							buildingState.OnLoad(gridPosition);
						}
					}
				}
				if(l<9){
                    l++;
                }else{
                    k++; l=0;
                }
            }
			
			if(isSecondFloor) secondPlane.SetActive(false);
        }
		
    }
}