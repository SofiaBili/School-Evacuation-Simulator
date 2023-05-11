using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class GridData
{
    Dictionary<Vector3Int, PlacementData> placedObjects = new();
    
    public static string[,,] schoolMapArray = new string[11,11,2];//10x10x2
    //ObjectPlacer objectPlacer;

    public void AddObjectAt(Vector3Int gridPosition, Vector2Int objectSize, int ID, int placedObjectIndex){
        List<Vector3Int> positionToOccupy = CalculatePosition(gridPosition, objectSize);
        PlacementData data = new PlacementData(positionToOccupy, ID, placedObjectIndex);
        foreach(var pos in positionToOccupy){
            //check if dictionary already contains
            if(placedObjects.ContainsKey(pos)){
                throw new Exception($"Dictionary already contains this cell position{pos}");
            }
            placedObjects[pos] = data;//assign to each occupied grid pos the data so that it can access it
        }
    }
    public void CompeleteMap(ObjectPlacer objectPlacer){
        int gameObjectIndex = -1;
        int i=0, j=0;
        for(int x=-5; x<=4; x++){
            j=0;
            for(int y=-5; y<=4; y++){
                Vector3Int vf = new Vector3Int(x,0,y);
                if(placedObjects.ContainsKey(vf)){
                    gameObjectIndex = GetRepresentationIndex(vf);
                    string roomID = placedObjects[vf].ID.ToString();
                    string rotation = objectPlacer.TakeObjectRotation(gameObjectIndex).ToString();
                    schoolMapArray[i,j,0] = roomID + "/" + rotation;
                    Debug.Log(i);
                    Debug.Log(j);
                }else{
                    schoolMapArray[i,j,0] = "-1";
                }
                j++;
            }
            i++;   
        }
        SceneManager.LoadScene("FloodDrillScene");
        Save();
    }
    private void Save(){
        File.WriteAllText(Application.dataPath+"/save.txt","test");
    }
    private List<Vector3Int> CalculatePosition(Vector3Int gridPosition, Vector2Int objectSize){
        List<Vector3Int> returnVal = new();
        //get the offset
        for(int x=0; x<objectSize.x; x++){
            for(int y=0; y<objectSize.y; y++){
                returnVal.Add(gridPosition + new Vector3Int(x,0,y));
            }
        }
        return returnVal;
    }
    public bool CanPlaceObjectAt(Vector3Int gridPosition, Vector2Int objectSize){
        List<Vector3Int> positionToOccupy = CalculatePosition(gridPosition, objectSize);
        foreach(var pos in positionToOccupy){
            if(placedObjects.ContainsKey(pos) || pos[0]>4 || pos[2]>4){
                return false;
            }
        }
        return true;
    } 
    public int GetRepresentationIndex(Vector3Int gridPosition)
    {
        if (placedObjects.ContainsKey(gridPosition) == false)
            return -1;
            
        return placedObjects[gridPosition].PlacedObjectIndex;
    }
    public void RemoveObjectAt(Vector3Int gridPosition)
    {
        //remove allthe keys representing the object
        foreach (var pos in placedObjects[gridPosition].occupiedPositions)
        {
            //Debug.Log(placedObjects[gridPosition].ID);
            placedObjects.Remove(pos);
        }
    }
    public int GetId(Vector3Int gridPosition){
        return placedObjects[gridPosition].ID;
    }
}


public class PlacementData{
    public List<Vector3Int> occupiedPositions;//positions occupied by this obj
    public int ID{get; private set;}
    public int PlacedObjectIndex{get; private set;}
    //constractor
    public PlacementData(List<Vector3Int> occupiedPositions, int iD, int placedObjectIndex){
        this.occupiedPositions = occupiedPositions;
        ID = iD;
        PlacedObjectIndex = placedObjectIndex;
    }
}
