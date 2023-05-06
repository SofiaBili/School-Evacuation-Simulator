using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    [SerializeField] GameObject empty;

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

    [SerializeField] GameObject corridorEndWall;
    [SerializeField] GameObject corridorAllWalls;
    [SerializeField] GameObject corridorEndWallLeft;
    [SerializeField] GameObject corridorEndWallRight;

    [SerializeField] GameObject corridorLeftWall;
    [SerializeField] GameObject corridorRightWall;
    [SerializeField] GameObject corridorBothWalls;
    [SerializeField] GameObject corridorNoWall;

    [SerializeField] GameObject corridorEndWallDoor;
    [SerializeField] GameObject corridorAllWallsFrontDoor;
    [SerializeField] GameObject corridorAllWallsLeftDoor;
    [SerializeField] GameObject corridorAllWallsRightDoor;
    [SerializeField] GameObject corridorEndWallFrontDoorLeft;
    [SerializeField] GameObject corridorEndWallFrontDoorRight;
    [SerializeField] GameObject corridorEndWallLeftDoor;
    [SerializeField] GameObject corridorEndWallRightDoor;
    
    [SerializeField] GameObject corridorBothWallsLeftDoor;
    [SerializeField] GameObject corridorBothWallsRightDoor;
    [SerializeField] GameObject corridorLeftWallDoor;
    [SerializeField] GameObject corridorRightWallDoor;

    [SerializeField] GameObject mapGameObject;
    public GameObject emptyGameObjectPrefab1;
    public GameObject emptyGameObjectPrefab2;
    private Vector3 savedPosition;
    
    public List<GameObject> hitboxes = new List<GameObject>();
    public static int hexagonNumber=0;
    public bool isFlood = false;
    
    void Awake(){
        savedPosition=mapGameObject.transform.position;
        //PlaceRoomsMethod();
        PlaceCustomRoomsMethod();
        ShowHitboxes();
    }

    void Start(){
        
    }

    void Update(){
        
    }
    public int GetHexagonNumber(){
        return hexagonNumber;
    }
    public void SetHexagonNumber(int newNum){
        hexagonNumber = newNum;        
    }
    void RoomName(GameObject roomName, int axis, int xValue, float zValue, GameObject floor, float degrees=0.0f, float yValue=0.0f){
        GameObject instantiatedObject;
        Transform room=null;
        savedPosition= savedPosition + new Vector3(-xValue, -yValue, -zValue);
        instantiatedObject=Instantiate(roomName);
        instantiatedObject.name = ""+roomName +"";
        instantiatedObject.transform.SetParent(floor.transform);
        instantiatedObject.transform.position = savedPosition;
        if(floor.name=="First Floor"){
            instantiatedObject.layer = LayerMask.NameToLayer("FirstFloor");
            room = instantiatedObject.transform.Find("room");
            if(room!=null){
                foreach(Transform thing in room.GetComponentsInChildren<Transform>())
                {
                    thing.gameObject.layer = LayerMask.NameToLayer("FirstFloor");
                }
            }
        }
        else if(floor.name=="Second Floor"){
            instantiatedObject.layer = LayerMask.NameToLayer("SecondFloor");
            room = instantiatedObject.transform.Find("room");
            if(room!=null){
                foreach(Transform thing in room.GetComponentsInChildren<Transform>())
                {
                    thing.gameObject.layer = LayerMask.NameToLayer("SecondFloor");
                }
            }
        }
        if(axis==1)
            instantiatedObject.transform.Rotate(degrees, 0.0f, 0.0f, Space.World);
        else if(axis==2)
            instantiatedObject.transform.Rotate(0.0f, degrees, 0.0f, Space.World);
        else if(axis==3)
            instantiatedObject.transform.Rotate(0.0f, 0.0f, degrees, Space.World);

        if(isFlood){
            //For flood check hexagon
            if(instantiatedObject.name.Contains("Stairs")){
                AddHitboxToList(instantiatedObject.transform.Find("Hexagon Hitbox").gameObject);
                AddHitboxToList(instantiatedObject.transform.Find("Hexagon Hitbox (1)").gameObject);
                AddHitboxToList(instantiatedObject.transform.Find("Hexagon Hitbox (2)").gameObject);
            }
            else if(instantiatedObject.transform.Find("Hexagon Hitbox")){
                AddHitboxToList(instantiatedObject.transform.Find("Hexagon Hitbox").gameObject);
            }
        }
    }
    void PlaceCustomRoomsMethod(){
    bool changeLineFlag = false;
    bool changeRowFlag = false;
    int yflag=1,xflag=0;
    for(int x=0; x<10; x++){
        for(int y=0; y<10; y++){
            string[] splitArray = GridData.schoolMapArray[x,y,0].Split(char.Parse("/"));
            if(int.Parse(splitArray[0])==-1){
                RoomName(empty,2,xflag,10*yflag,emptyGameObjectPrefab2,0,0f);
            }
            if(int.Parse(splitArray[0])==0){
                //GameObject roomName, int axis, int xValue, float zValue, GameObject floor, float degrees=0.0f, float yValue=0.0f){

                RoomName(classRoom,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
            }else if(int.Parse(splitArray[0])==6){
                //GameObject roomName, int axis, int xValue, float zValue, GameObject floor, float degrees=0.0f, float yValue=0.0f){

                RoomName(office1,2,x,10,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
            }
            if(changeRowFlag){
                xflag=0;
                changeRowFlag=false;
                if(!changeLineFlag){
                    yflag=1;
                }
                else{
                    yflag=-1;
                }
            }

        }
        changeRowFlag=true;
        yflag=0;
        xflag=10;

        if(!changeLineFlag){
            changeLineFlag=true;
        }
        else{
            changeLineFlag=false;
        }
    }

}

    void PlaceRoomsMethod(){
        //First Floor
        emptyGameObjectPrefab1.name = "First Floor";
        RoomName(theaterRoom1,0,0,10,emptyGameObjectPrefab1);
        RoomName(corridorLeftWallDoor,2,0,10,emptyGameObjectPrefab1,90);
        RoomName(corridorLeftWall,2,0,10,emptyGameObjectPrefab1,90);
        RoomName(office1,0,0,10,emptyGameObjectPrefab1);
        RoomName(office2,0,0,10,emptyGameObjectPrefab1);
        RoomName(corridorNoWall,2,0,10,emptyGameObjectPrefab1,90);
        RoomName(corridorEndWallDoor,2,0,10,emptyGameObjectPrefab1,270);
        
        RoomName(labRoom2,2,10,0,emptyGameObjectPrefab1,270.0f);
        RoomName(labRoom1,2,0,-10,emptyGameObjectPrefab1,270.0f);
        
        RoomName(wc,0,-20,10,emptyGameObjectPrefab1);
        RoomName(classRoom,2,0,-10,emptyGameObjectPrefab1,90.0f);
        RoomName(office3,0,0,-10,emptyGameObjectPrefab1);
        RoomName(office4,0,0,-10,emptyGameObjectPrefab1);
        RoomName(elevator,2,0,-10,emptyGameObjectPrefab1,180);
        RoomName(stairs,2,0,-10,emptyGameObjectPrefab1,270);
        RoomName(theaterRoom2,0,0,-10,emptyGameObjectPrefab1);
        
        //Second Floor
        emptyGameObjectPrefab2.name = "Second Floor";
        RoomName(classRoom,2,0,-10,emptyGameObjectPrefab2,90,-5.001f);
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,90,0);
        //RoomName(stairs,0,0,10,emptyGameObjectPrefab2);
        //RoomName(elevator,0,0,20,emptyGameObjectPrefab2);
        RoomName(informatics,0,0,30,emptyGameObjectPrefab2);
        RoomName(classRoom,2,0,20,emptyGameObjectPrefab2,90,0);
        RoomName(wc,0,0,10,emptyGameObjectPrefab2);

        RoomName(corridorEndWall,2,10,0,emptyGameObjectPrefab2,90,0);
        RoomName(corridorNoWall,2,0,-10,emptyGameObjectPrefab2,90,0);
        RoomName(corridorRightWall,2,0,-10,emptyGameObjectPrefab2,90);
        RoomName(corridorNoWall,2,0,-10,emptyGameObjectPrefab2,90);
        RoomName(corridorLeftWall,2,0,-10,emptyGameObjectPrefab2,90);
        RoomName(corridorNoWall,2,0,-10,emptyGameObjectPrefab2,90);
        RoomName(corridorNoWall,2,0,-10,emptyGameObjectPrefab2,90);
        RoomName(corridorEndWall,2,0,-10,emptyGameObjectPrefab2,270);

        RoomName(classRoom,2,10,0,emptyGameObjectPrefab2,-90,0);
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,-90,0);
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,-90,0);
        RoomName(classRoom,2,0,20,emptyGameObjectPrefab2,-90,0);
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,-90,0);
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,-90,0); 
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,-90,0); 
    }
    
    void AddHitboxToList(GameObject hitbox){
        hitboxes.Add(hitbox);
    }
    void ShowHitboxes(){
        int randomNumber;
        if(hitboxes.Count<=15){
            for(hexagonNumber=0; hexagonNumber<hitboxes.Count; hexagonNumber++){
                hitboxes[hexagonNumber].SetActive(true);
            }
        }else{
            for(hexagonNumber=0; hexagonNumber<15; hexagonNumber++){
                randomNumber = Random.Range(0, hitboxes.Count);
                hitboxes[randomNumber].SetActive(true);
                hitboxes.RemoveAt(randomNumber);
            }
        }
    }
}
