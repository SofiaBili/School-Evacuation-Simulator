using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

    string[] splitAtHashtag;
    string[,,] schoolMapArray = new string[11,11,2];
    
    public static bool isDefault = true;

    void Awake(){
        savedPosition=mapGameObject.transform.position;
        Placement();
        //PlaceCustomRoomsMethod();
        ShowHitboxes();
    }

    void Start(){
        
    }
    public static void ChooseCustomOrDef(bool choice = true){
        isDefault = choice;
    }
    public void Placement(){
        if(isDefault){
            PlaceRoomsMethod();
        }else{
            PlaceCustomRoomsMethod();
        }
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
        Transform room=null, hitbox = null;
        savedPosition= savedPosition + new Vector3(-xValue, -yValue, -zValue);
        instantiatedObject=Instantiate(roomName);
        instantiatedObject.name = ""+roomName +"";
        instantiatedObject.transform.SetParent(floor.transform);
        instantiatedObject.transform.position = savedPosition;
        if(floor.name=="First Floor"){
            instantiatedObject.layer = LayerMask.NameToLayer("FirstFloor");
            room = instantiatedObject.transform.Find("room");
            hitbox = instantiatedObject.transform.Find("Hexagon Hitbox");
            if(room!=null){
                foreach(Transform thing in room.GetComponentsInChildren<Transform>())
                {
                    thing.gameObject.layer = LayerMask.NameToLayer("FirstFloor");
                }
            }
            if(hitbox!=null){
                foreach(Transform thing in hitbox.GetComponentsInChildren<Transform>())
                {
                    thing.gameObject.layer = LayerMask.NameToLayer("FirstFloor");
                }
            }
        }
        else if(floor.name=="Second Floor"){
            instantiatedObject.layer = LayerMask.NameToLayer("SecondFloor");
            room = instantiatedObject.transform.Find("room");
            hitbox = instantiatedObject.transform.Find("Hexagon Hitbox");
            if(room!=null){
                foreach(Transform thing in room.GetComponentsInChildren<Transform>())
                {
                    thing.gameObject.layer = LayerMask.NameToLayer("SecondFloor");
                }
            }
            if(hitbox!=null){
                foreach(Transform thing in hitbox.GetComponentsInChildren<Transform>())
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
    private void LoadFile(){
        int floor;
        int x=0, y=0, k=0, l=0;
        string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
        splitAtHashtag = saveString.Split(char.Parse("#"));
        Debug.Log(splitAtHashtag.Length-1);
        schoolMapArray = new string[11,11,2];
        for(int i=0; i<splitAtHashtag.Length-1; i++){//-1 because last # is empty
            if(int.Parse(splitAtHashtag[i].Split(char.Parse("/"))[2]) == 0){
                //Debug.Log(splitAtHashtag[i]);
                schoolMapArray[x,y,0] = splitAtHashtag[i];
                if(y<9){
                    y++;
                }else{
                    x++; y=0;
                }
            }else{
                schoolMapArray[k,l,1] = splitAtHashtag[i];
                if(l<9){
                    l++;
                }else{
                    k++; l=0;
                }
            }
        }
    }
    void PlaceCustomRoomsMethod(){
        bool changeLineFlag = false;
        bool changeRowFlag = false;
        int yflag,xflag;
        int roomID;
        string[] splitArray;
        LoadFile();
        for(int f=0; f<2; f++){
            yflag=1; xflag=0;
            for(int x=0; x<schoolMapArray.GetLength(0)-1; x++){
                for(int y=0; y<schoolMapArray.GetLength(1)-1; y++){
                    if(!changeLineFlag){
                        splitArray = schoolMapArray[x,y,f].Split(char.Parse("/"));
                    }
                    else{
                        //go the opposite way in line
                        splitArray = schoolMapArray[x,9-y,f].Split(char.Parse("/"));
                    }
                    roomID = int.Parse(splitArray[0]);
                    if(roomID==-1){
                        RoomName(empty,2,xflag,10*yflag,emptyGameObjectPrefab2,0,0f);
                    }else if(roomID==0){
                        RoomName(classRoom,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==1){
                        RoomName(labRoom1,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==-2){
                        RoomName(labRoom2,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==2){
                        RoomName(labRoom2,2,xflag,10*yflag,emptyGameObjectPrefab2,90,0f);
                    }else if(roomID==-3){
                        RoomName(labRoom1,2,xflag,10*yflag,emptyGameObjectPrefab2,90,0f);
                    }else if(roomID==3){
                        RoomName(labRoom2,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==-4){
                        RoomName(labRoom1,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==4){
                        RoomName(labRoom1,2,xflag,10*yflag,emptyGameObjectPrefab2,270,0f);
                    }else if(roomID==-5){
                        RoomName(labRoom2,2,xflag,10*yflag,emptyGameObjectPrefab2,270,0f);
                    }else if(roomID==5){
                        RoomName(theaterRoom2,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==-6){
                        RoomName(theaterRoom1,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==10){
                        RoomName(theaterRoom1,2,xflag,10*yflag,emptyGameObjectPrefab2,90,0f);
                    }else if(roomID==-11){
                        RoomName(theaterRoom2,2,xflag,10*yflag,emptyGameObjectPrefab2,90,0f);
                    }else if(roomID==11){
                        RoomName(theaterRoom1,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==-12){
                        RoomName(theaterRoom2,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==12){
                        RoomName(theaterRoom2,2,xflag,10*yflag,emptyGameObjectPrefab2,270,0f);
                    }else if(roomID==-13){
                        RoomName(theaterRoom1,2,xflag,10*yflag,emptyGameObjectPrefab2,270,0f);
                    }else if(roomID==6){
                        RoomName(office3,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==7){
                        RoomName(wc,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==8){
                        RoomName(stairs,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==9){
                        RoomName(elevator,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==13){
                        RoomName(corridorNoWall,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==14){
                        RoomName(corridorRightWallDoor,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==15){
                        RoomName(corridorRightWall,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==16){
                        RoomName(corridorBothWalls,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==17){
                        RoomName(corridorAllWallsFrontDoor,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==18){
                        RoomName(corridorAllWallsLeftDoor,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==19){
                        RoomName(corridorAllWallsRightDoor,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==20){
                        RoomName(corridorAllWalls,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==21){
                        RoomName(corridorEndWallDoor,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==22){
                        RoomName(corridorEndWallFrontDoorLeft,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==23){
                        RoomName(corridorEndWallFrontDoorRight,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==24){
                        RoomName(corridorEndWallLeftDoor,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==25){
                        RoomName(corridorEndWallLeft,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==26){
                        RoomName(corridorEndWallRightDoor,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==27){
                        RoomName(corridorEndWallRight,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==28){
                        RoomName(corridorEndWall,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==29){
                        RoomName(corridorBothWallsLeftDoor,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==30){
                        RoomName(corridorLeftWallDoor,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==31){
                        RoomName(corridorLeftWall,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }else if(roomID==32){
                        RoomName(informatics,2,xflag,10*yflag,emptyGameObjectPrefab2,int.Parse(splitArray[1]),0f);
                    }
                    if(changeRowFlag){
                        //empty room to go one right and one pos above grid
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
            RoomName(empty,2,-90,-10,emptyGameObjectPrefab2,0,-5.001f);
        }

    }

    void PlaceRoomsMethod(){
        //First Floor
        emptyGameObjectPrefab1.name = "First Floor";
        RoomName(theaterRoom1,0,0,10,emptyGameObjectPrefab1);
        RoomName(corridorLeftWallDoor,2,0,10,emptyGameObjectPrefab1,-90);
        RoomName(corridorLeftWall,2,0,10,emptyGameObjectPrefab1,-90);
        RoomName(office1,0,0,10,emptyGameObjectPrefab1);
        RoomName(office2,0,0,10,emptyGameObjectPrefab1);
        RoomName(corridorNoWall,2,0,10,emptyGameObjectPrefab1,90);
        RoomName(corridorEndWallDoor,2,0,10,emptyGameObjectPrefab1,270);
        
        RoomName(labRoom2,2,10,0,emptyGameObjectPrefab1,270.0f);
        RoomName(labRoom1,2,0,-10,emptyGameObjectPrefab1,270.0f);
        
        RoomName(wc,2,-20,10,emptyGameObjectPrefab1,90f);
        RoomName(classRoom,2,0,-10,emptyGameObjectPrefab1,90.0f);
        RoomName(office3,2,0,-10,emptyGameObjectPrefab1,90f);
        RoomName(office4,0,0,-10,emptyGameObjectPrefab1);
        RoomName(elevator,2,0,-10,emptyGameObjectPrefab1,90);
        RoomName(stairs,2,0,-10,emptyGameObjectPrefab1,90);
        RoomName(theaterRoom2,0,0,-10,emptyGameObjectPrefab1);
        
        //Second Floor
        emptyGameObjectPrefab2.name = "Second Floor";
        RoomName(classRoom,2,0,-10,emptyGameObjectPrefab2,90,-5.001f);
        RoomName(classRoom,2,0,10,emptyGameObjectPrefab2,90,0);
        RoomName(informatics,2,0,30,emptyGameObjectPrefab2,90);
        RoomName(classRoom,2,0,20,emptyGameObjectPrefab2,90,0);
        RoomName(wc,2,0,10,emptyGameObjectPrefab2,90);

        RoomName(corridorEndWall,2,10,0,emptyGameObjectPrefab2,180,0);
        RoomName(corridorNoWall,2,0,-10,emptyGameObjectPrefab2,90,0);
        RoomName(corridorRightWall,2,0,-10,emptyGameObjectPrefab2,-90);
        RoomName(corridorNoWall,2,0,-10,emptyGameObjectPrefab2,90);
        RoomName(corridorLeftWall,2,0,-10,emptyGameObjectPrefab2,-90);
        RoomName(corridorNoWall,2,0,-10,emptyGameObjectPrefab2,90);
        RoomName(corridorNoWall,2,0,-10,emptyGameObjectPrefab2,90);
        RoomName(corridorEndWall,2,0,-10,emptyGameObjectPrefab2,0);

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
