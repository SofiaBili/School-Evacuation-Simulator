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
    private Vector3 savedPosition;

    private int mapRow=1,mapCol=5;

    void Awake(){
    }

    void Start(){
        mapRow=1;
        mapCol=5;
        savedPosition=mapGameObject.transform.position;
        PlaceRoomsMethod();
    }

    void Update(){
        
    }
    void RoomName(GameObject roomName, int i, int j, int axis, int xValue, float zValue, float degrees=0.0f, float yValue=0.0f){
        GameObject instantiatedObject;
        savedPosition= savedPosition + new Vector3(-xValue, -yValue, -zValue);
        instantiatedObject=Instantiate(roomName);
        instantiatedObject.name = ""+roomName +""+ (i+1).ToString() + " " + (j+1).ToString();
        instantiatedObject.transform.SetParent(mapGameObject.transform);
        instantiatedObject.transform.position = savedPosition;
        if(axis==1)
            instantiatedObject.transform.Rotate(degrees, 0.0f, 0.0f, Space.World);
        else if(axis==2)
            instantiatedObject.transform.Rotate(0.0f, degrees, 0.0f, Space.World);
        else if(axis==3)
            instantiatedObject.transform.Rotate(0.0f, 0.0f, degrees, Space.World);
    }
    void PlaceRoomsMethod(){
        int i=0,j=0;
        //RoomName(labRoom,i,j,0,0);
        //i++; j=0; savedPosition= savedPosition + new Vector3(-10.0f, 0.0f, mapCol*10.0f);
        
        //savedPosition= savedPosition + new Vector3(-10.0f, 0.0f, mapCol*10.0f);
        RoomName(theaterRoom1,i,j,0,0,10);
        RoomName(corridor4,i,j,2,0,10,90.0f);
        RoomName(corridor4,i,j,2,0,10,90.0f);
        RoomName(office1,i,j,0,0,10);
        RoomName(office2,i,j,0,0,10);
        RoomName(corridor22,i,j,2,0,10,90);
        RoomName(corridor21,i,j,2,0,10,90);
        //i+=1; j=0; savedPosition= savedPosition + new Vector3(-10.0f, 0.0f, mapCol*10.0f);
        RoomName(labRoom2,i,j,2,10,0,-90);
        RoomName(labRoom1,i,j,2,0,-10,-90);
        //i-=2; j=0; savedPosition= savedPosition + new Vector3(-10.0f, 0.0f, mapCol*10.0f);
        RoomName(wc,i,j,0,-20,10);
        RoomName(classRoom,i,j,2,0,-10,90);
        RoomName(office3,i,j,0,0,-10);
        RoomName(office4,i,j,0,0,-10);
        RoomName(elevator,i,j,0,0,-10);
        RoomName(stairs,i,j,0,0,-10);
        RoomName(theaterRoom2,i,j,0,0,-10);
        
        //Second Floor
        RoomName(classRoom,i,j,2,0,-10,90,-5);
        RoomName(classRoom,i,j,2,0,10,90,0);
        RoomName(stairs,i,j,0,0,10,0,0);
        RoomName(elevator,i,j,0,0,10,0,0);
        RoomName(informatics,i,j,0,0,10,0,0);
        RoomName(classRoom,i,j,2,0,20,90,0);
        RoomName(wc,i,j,0,0,10,0,0);
        RoomName(corridor21,i,j,0,10,0,0,0);
        RoomName(corridor22,i,j,0,0,-10,0,0);
        RoomName(corridor51,i,j,0,0,-10,0,0);
        RoomName(corridor52,i,j,0,0,-10,0,0);
        RoomName(corridor61,i,j,0,0,-10,0,0);
        RoomName(corridor62,i,j,0,0,-10,0,0);
        RoomName(corridor22,i,j,0,0,-10,0,0);
        RoomName(corridor21,i,j,0,0,-10,0,0);
        RoomName(classRoom,i,j,0,10,0,0,0);
        RoomName(classRoom,i,j,0,0,10,0,0);
        RoomName(classRoom,i,j,0,0,10,0,0);
        RoomName(classRoom,i,j,0,0,30,0,0);
        RoomName(classRoom,i,j,0,0,10,0,0);
        RoomName(classRoom,i,j,0,0,10,0,0); 

        //Place rooms
        
    }
}
