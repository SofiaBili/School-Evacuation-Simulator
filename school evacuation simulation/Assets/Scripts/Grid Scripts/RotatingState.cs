using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingState : IBuildingState
{
    private int gameObjectIndex = -1;
    Grid grid;
    PreviewSystem previewSystem;
    GridData floorData;
    GridData furnitureData;
    ObjectPlacer objectPlacer;
    //SoundFeedback soundFeedback; 

    public RotatingState(Grid grid,  PreviewSystem previewSystem, GridData floorData, GridData furnitureData, ObjectPlacer objectPlacer)//, SoundFeedback soundFeedback)
    {
        this.grid = grid;
        this.previewSystem = previewSystem;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        this.objectPlacer = objectPlacer;
        //this.soundFeedback = soundFeedback;
        previewSystem.StartShowingRotatePreview();
    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {
        GridData selectedData = null;
        //if this is on the specific cell
        if(!furnitureData.CanPlaceObjectAt(gridPosition,Vector2Int.one))
        {
            selectedData = furnitureData;
        }
        else if(!floorData.CanPlaceObjectAt(gridPosition, Vector2Int.one))
        {
            selectedData = floorData;
        }

        if(selectedData == null)
        {
            //sound
            //soundFeedback.PlaySound(SoundType.wrongPlacement);
        }
        else
        {
            //soundFeedback.PlaySound(SoundType.Remove);
            gameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);
            if (gameObjectIndex == -1)
                return;
            //rotate the object
            Debug.Log("LLLLLLLLL"+selectedData);
            Debug.Log("kkkkkkk"+objectPlacer);
            objectPlacer.RotateObjectAt(gameObjectIndex);
            //selectedData.RemoveObjectAt(gridPosition);
            //objectPlacer.RemoveObjectAt(gameObjectIndex);
        }
        //update preview
        Vector3 cellPosition = grid.CellToWorld(gridPosition);
        previewSystem.UpdatePosition(cellPosition, CheckIfSelectionIsValid(gridPosition));
    }

    private bool CheckIfSelectionIsValid(Vector3Int gridPosition)
    {
        //check if position is free
        return !(furnitureData.CanPlaceObjectAt(gridPosition, Vector2Int.one) &&
            floorData.CanPlaceObjectAt(gridPosition, Vector2Int.one));
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        bool validity = CheckIfSelectionIsValid(gridPosition);
        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), validity);
    }
}
