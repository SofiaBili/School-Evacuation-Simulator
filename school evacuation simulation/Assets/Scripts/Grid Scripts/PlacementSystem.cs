using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicator;
    [SerializeField] private InputManager inputManager;
	[SerializeField] private Grid grid;

	[SerializeField] private ObjectsDatabase database;
	private int selectedObjectIndex = -1;
	
	[SerializeField] private PreviewSystem preview;
	//trigger grid visualization
	[SerializeField] private GameObject gridVisualization;

	private List<GameObject> placedGameObjects = new List<GameObject>();

    private GridData floorData, furnitureData;
	private Vector3Int lastDetectedPosition = Vector3Int.zero;
	private void Start(){
		StopPlacement();
		floorData = new GridData();
		furnitureData = new GridData();
		
	}
	public void StartPlacement(int ID){
		StopPlacement();
		selectedObjectIndex = database.objectsData.FindIndex(data => data.ID==ID);//return index if data.id==id
		if(selectedObjectIndex<0){//no valid id
			Debug.LogError($"No ID found{ID}");
			return;
		}
		gridVisualization.SetActive(true);
		preview.StartShowingPlacementPreview(database.objectsData[selectedObjectIndex].Prefab, database.objectsData[selectedObjectIndex].Size);
		inputManager.OnClicked += PlaceStructure;
		inputManager.OnExit += StopPlacement;
	}
	public void PlaceStructure(){
		if(inputManager.IsPointerOverUI()){
			return;
		}
		Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
		
		bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
		if(!placementValidity){
			return;
		}

		GameObject newObject = Instantiate(database.objectsData[selectedObjectIndex].Prefab);
		newObject.transform.position = grid.CellToWorld(gridPosition);
		placedGameObjects.Add(newObject);
		GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ? floorData : furnitureData;
		selectedData.AddObjectAt(gridPosition, database.objectsData[selectedObjectIndex].Size, database.objectsData[selectedObjectIndex].ID, placedGameObjects.Count-1);
		preview.UpdatePosition(grid.CellToWorld(gridPosition), false);
	}
	public bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex){
		GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ? floorData : furnitureData;
		return selectedData.CanPlaceObjectAt(gridPosition, database.objectsData[selectedObjectIndex].Size);
	}
	public void StopPlacement(){
		selectedObjectIndex = -1;
		gridVisualization.SetActive(false);
		preview.StopShowingPreview();
		inputManager.OnClicked -= PlaceStructure;
		inputManager.OnExit -= StopPlacement;
		lastDetectedPosition = Vector3Int.zero;
	}
    private void Update(){
		if(selectedObjectIndex<0)
			return;
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
		if(lastDetectedPosition != gridPosition){
			bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
			
			mouseIndicator.transform.position = mousePosition;
			preview.UpdatePosition(grid.CellToWorld(gridPosition), placementValidity);
			lastDetectedPosition = gridPosition;
		}
	}
}