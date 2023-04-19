using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicator, cellIndicator;
    [SerializeField] private InputManager inputManager;
	[SerializeField] private Grid grid;

	[SerializeField] private ObjectsDatabase database;
	private int selectedObjectIndex = -1;
	
	//trigger grid visualization
	[SerializeField] private GameObject gridVisualization;
	//private Renderer previewRenderer;
	private List<GameObject> placedGameObjects = new();

    //private GridData floorData, furnitureData;
	private void Start(){
		StopPlacement();
		//floorData = new();
		//furnitureData = new();
		//previewRenderer = cellIndicator.GetComponentsInChildren<Renderer>();
	}
	public void StartPlacement(int ID){
		StopPlacement();
		selectedObjectIndex = database.objectsData.FindIndex(data => data.ID==ID);//return index if data.id==id
		if(selectedObjectIndex<0){//no valid id
			Debug.LogError($"No ID found{ID}");
			return;
		}
		gridVisualization.SetActive(true);
		cellIndicator.SetActive(true);
		inputManager.OnClicked += PlaceStructure;
		inputManager.OnExit += StopPlacement;
	}
	public void PlaceStructure(){
		if(inputManager.IsPointerOverUI()){
			return;
		}
		Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
		GameObject newObject = Instantiate(database.objectsData[selectedObjectIndex].Prefab);
		newObject.transform.position = grid.CellToWorld(gridPosition);
   
	}
	public void StopPlacement(){
		selectedObjectIndex = -1;
		gridVisualization.SetActive(false);
		cellIndicator.SetActive(false);
		inputManager.OnClicked -= PlaceStructure;
		inputManager.OnExit -= StopPlacement;
	}
    private void Update(){
		if(selectedObjectIndex<0)
			return;
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
		mouseIndicator.transform.position = mousePosition;
		cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}