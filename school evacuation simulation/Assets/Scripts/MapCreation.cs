using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    [SerializeField] GameObject theaterRoom1;
    [SerializeField] GameObject theaterRoom2;
    [SerializeField] GameObject stairs;
    [SerializeField] GameObject elevator;
    [SerializeField] GameObject office1;
    [SerializeField] GameObject office2;
    [SerializeField] GameObject office3;
    [SerializeField] GameObject office4;
    [SerializeField] GameObject classRoom;
    [SerializeField] GameObject wc;
    [SerializeField] GameObject labRoom1;
    [SerializeField] GameObject labRoom2;
    [SerializeField] GameObject informatics;

    [SerializeField] GameObject corridor21;
    [SerializeField] GameObject corridor22;
    [SerializeField] GameObject corridor4;
    [SerializeField] GameObject corridor51;
    [SerializeField] GameObject corridor52;
    [SerializeField] GameObject corridor61;
    [SerializeField] GameObject corridor62;

    [SerializeField] GameObject mapGameObject;
    public GameObject emptyGameObjectPrefab1;
    public GameObject emptyGameObjectPrefab2;
    private Vector3 savedPosition;

    void Awake(){
    }

    void Start(){
        savedPosition=mapGameObject.transform.position;
        PlaceRoomsMethod();
    }

    void Update(){
        
    }
    void RoomName(GameObject roomName, int axis, int xValue, float zValue, GameObject floor, float degrees=0.0f, float yValue=0.0f){
        GameObject instantiatedObject;
        savedPosition= savedPosition + new Vector3(-xValue, -yValue, -zValue);
        instantiatedObject=Instantiate(roomName);
        instantiatedObject.name = ""+roomName +"";
        instantiatedObject.transform.SetParent(floor.transform);
        instantiatedObject.transform.position = savedPosition;
        if(axis==1)
            instantiatedObject.transform.Rotate(degrees, 0.0f, 0.0f, Space.World);
        else if(axis==2)
            instantiatedObject.transform.Rotate(0.0f, degrees, 0.0f, Space.World);
        else if(axis==3)
            instantiatedObject.transform.Rotate(0.0f, 0.0f, degrees, Space.World);
    }
    void PlaceRoomsMethod(){
        //First Floor
        Instantiate(emptyGameObjectPrefab1, transform.position,Quaternion.identity);
        emptyGameObjectPrefab1.name = "First Floor";
        RoomName(theaterRoom1,0,0,10,emptyGameObjectPrefab1);
        RoomName(corridor4,2,0,10,emptyGameObjectPrefab1,90.0f);
        RoomName(corridor4,2,0,10,emptyGameObjectPrefab1,90.0f);
        RoomName(office1,0,0,10,emptyGameObjectPrefab1);
        RoomName(office2,0,0,10,emptyGameObjectPrefab1);
        RoomName(corridor22,2,0,10,emptyGameObjectPrefab1,90.0f);
        RoomName(corridor21,2,0,10,emptyGameObjectPrefab1,90.0f);
        
        RoomName(labRoom2,2,10,0,emptyGameObjectPrefab1,270.0f);
        RoomName(labRoom1,2,0,-10,emptyGameObjectPrefab1,270.0f);
        
        RoomName(wc,0,-20,10,emptyGameObjectPrefab1);
        RoomName(classRoom,2,0,-10,emptyGameObjectPrefab1,90.0f);
        RoomName(office3,0,0,-10,emptyGameObjectPrefab1);
        RoomName(office4,0,0,-10,emptyGameObjectPrefab1);
        RoomName(elevator,0,0,-10,emptyGameObjectPrefab1);
        RoomName(stairs,0,0,-10,emptyGameObjectPrefab1);
        RoomName(theaterRoom2,0,0,-10,emptyGameObjectPrefab1);
        
        //Second Floor
        Instantiate(emptyGameObjectPrefab2, transform.position,Quaternion.identity);
        emptyGameObjectPrefab2.name = "Second Floor";
        RoomName(classRoom,2,0,-10,emptyGameObjectPrefab2,90,-5.001f);
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,90,0);
        RoomName(stairs,0,0,10,emptyGameObjectPrefab2);
        RoomName(elevator,0,0,10,emptyGameObjectPrefab2);
        RoomName(informatics,0,0,10,emptyGameObjectPrefab2);
        RoomName(classRoom,2,0,20,emptyGameObjectPrefab2,90,0);
        RoomName(wc,0,0,10,emptyGameObjectPrefab2);

        RoomName(corridor21,2,10,0,emptyGameObjectPrefab2,90,0);
        RoomName(corridor22,2,0,-10,emptyGameObjectPrefab2,90,0);
        RoomName(corridor51,2,0,-10,emptyGameObjectPrefab2,180);
        RoomName(corridor52,2,0,-10,emptyGameObjectPrefab2,180);
        RoomName(corridor61,0,0,-10,emptyGameObjectPrefab2);
        RoomName(corridor62,0,0,-10,emptyGameObjectPrefab2);
        RoomName(corridor22,2,0,-10,emptyGameObjectPrefab2,270);
        RoomName(corridor21,2,0,-10,emptyGameObjectPrefab2,270);

        RoomName(classRoom,2,10,0,emptyGameObjectPrefab2,-90,0);
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,-90,0);
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,-90,0);
        RoomName(classRoom,2,0,20,emptyGameObjectPrefab2,-90,0);
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,-90,0);
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,-90,0); 
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,-90,0); 
    }
}
