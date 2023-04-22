using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

	IBuildingState buildingState;

	private void Start(){
		StopPlacement();
		floorData = new GridData();
		furnitureData = new GridData();
		
	}
	public void StartPlacement(int ID){
		StopPlacement();
		gridVisualization.SetActive(true);
		buildingState = new PlacementState(ID, grid, preview, database, floorData, furnitureData, objectPlacer);
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
	public void PlaceStructure(){
		if(inputManager.IsPointerOverUI()){
			return;
		}
		Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
		buildingState.OnAction(gridPosition);
	}
	// public bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex){
	// 	GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ? floorData : furnitureData;
	// 	return selectedData.CanPlaceObjectAt(gridPosition, database.objectsData[selectedObjectIndex].Size);
	// }
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
}