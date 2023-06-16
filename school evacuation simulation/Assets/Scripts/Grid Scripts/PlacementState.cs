using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlacementState : IBuildingState
{
    private int selectedObjectIndex = -1;
    int ID;
    Grid grid;
    PreviewSystem previewSystem;
    ObjectsDatabase database;
    GridData floorData;
    GridData furnitureData;
    ObjectPlacer objectPlacer;

    GameObject parentObj;
    //SoundFeedback soundFeedback;

    public PlacementState(int iD, Grid grid, PreviewSystem previewSystem, ObjectsDatabase database, GridData floorData, GridData furnitureData, ObjectPlacer objectPlacer, GameObject parObj)//, SoundFeedback soundFeedback)
    {
        ID = iD;
        this.grid = grid;
        this.previewSystem = previewSystem;
        this.database = database;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        this.objectPlacer = objectPlacer;
        this.parentObj = parObj;
        //this.soundFeedback = soundFeedback;

        selectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID);
        //we have the correct index
        if (selectedObjectIndex > -1 || EditOrNewFile.replacementOfFile)
        {
            previewSystem.StartShowingPlacementPreview(database.objectsData[selectedObjectIndex].Prefab, database.objectsData[selectedObjectIndex].Size);
        }
        else
            throw new System.Exception($"No object with ID {iD}");
        
    }
    //general logic
    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }
//what happens when we want to create an action on button press
    public void OnAction(Vector3Int gridPosition)
    {

        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        Debug.Log(placementValidity);
        if (placementValidity == false)
        {
            SpeachText.instance.SetAndShowPanel("Δεν μπορείς να τοποθετήσεις αυτό το αντικείμενο εδώ");
          //  soundFeedback.PlaySound(SoundType.wrongPlacement);
            return;
        }
        //soundFeedback.PlaySound(SoundType.Place);
        int index = objectPlacer.PlaceObject(database.objectsData[selectedObjectIndex].Prefab, grid.CellToWorld(gridPosition), parentObj);

        GridData selectedData = database.objectsData[selectedObjectIndex].ID == -1 ? floorData : furnitureData;
        selectedData.AddObjectAt(gridPosition, database.objectsData[selectedObjectIndex].Size, database.objectsData[selectedObjectIndex].ID, index);

        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), false);
    }

    public void OnLoad(Vector3Int gridPosition){
        int index = objectPlacer.PlaceObject(database.objectsData[selectedObjectIndex].Prefab, grid.CellToWorld(gridPosition), parentObj);

        GridData selectedData = database.objectsData[selectedObjectIndex].ID == -1 ? floorData : furnitureData;
        selectedData.AddObjectAt(gridPosition, database.objectsData[selectedObjectIndex].Size, database.objectsData[selectedObjectIndex].ID, index);

        //previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), false);
    }

    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    {
        GridData selectedData = database.objectsData[selectedObjectIndex].ID == -1 ? floorData : furnitureData;

        return selectedData.CanPlaceObjectAt(gridPosition, database.objectsData[selectedObjectIndex].Size);
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);

        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), placementValidity);
    }
}
