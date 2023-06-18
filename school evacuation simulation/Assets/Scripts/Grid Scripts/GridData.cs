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
    string[] splitAtHashtag;
    
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
    public void CompeleteMap(ObjectPlacer objectPlacer, int floor){
        
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
                    if(schoolMapArray[i,j,floor]==null){
                        schoolMapArray[i,j,floor] = roomID + "/" + rotation+"/"+floor;
                        //lab
                        if(roomID=="1"){roomID="-2"; schoolMapArray[i+1,j,floor] = roomID + "/" + rotation+"/"+floor;}
                        if(roomID=="2"){roomID="-3"; schoolMapArray[i,j+1,floor] = roomID + "/" + rotation+"/"+floor;}
                        if(roomID=="3"){roomID="-4"; schoolMapArray[i+1,j,floor] = roomID + "/" + rotation+"/"+floor;}
                        if(roomID=="4"){roomID="-5"; schoolMapArray[i,j+1,floor] = roomID + "/" + rotation+"/"+floor;}
                        
                        //theater
                        if(roomID=="5"){roomID="-6"; schoolMapArray[i+1,j,floor] = roomID + "/" + rotation+"/"+floor;}
                        if(roomID=="10"){roomID="-11"; schoolMapArray[i,j+1,floor] = roomID + "/" + rotation+"/"+floor;}
                        if(roomID=="11"){roomID="-12"; schoolMapArray[i+1,j,floor] = roomID + "/" + rotation+"/"+floor;}
                        if(roomID=="12"){roomID="-13"; schoolMapArray[i,j+1,floor] = roomID + "/" + rotation+"/"+floor;}
                    }
                    //Debug.Log(i);
                    //Debug.Log(j);
                }else{
                    schoolMapArray[i,j,floor] = "-1/0/"+floor;
                }
                j++;
            }
            i++;   
        }
        Save(floor);
        SceneManager.LoadScene("SelectCustomOrDefaultScene");
    }
    private void Save(int floor){
        string saveData = null;
        for(int i=0; i<10; i++){
            for(int j=0; j<10; j++){
                saveData += schoolMapArray[i,j,floor]+"#";
                //Debug.Log(saveData);
            }
        }
        if(!String.IsNullOrEmpty(saveData))
            File.AppendAllText(Application.dataPath+"/save.txt",saveData);
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
