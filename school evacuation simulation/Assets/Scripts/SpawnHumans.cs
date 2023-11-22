using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHumans : MonoBehaviour
{

    [SerializeField] GameObject maleHumanPrefab;
    [SerializeField] GameObject femaleHumanPrefab;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject teacherPrefab;
    [SerializeField] GameObject mapGameObject;
    [SerializeField] GameObject humansGameObject;

    List<Transform> spawns = new List<Transform>();
    List<Transform> teacherSpawns = new List<Transform>();
    public List<GameObject> humans = new List<GameObject>();
    GameObject instantiatedObject;
    bool playerSpawnFlag = true;

    // Start is called before the first frame update
    void Start() {
        FindAllSpawns();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FindAllSpawns(){
        foreach(Transform thing in mapGameObject.GetComponentsInChildren<Transform>()){
            //Debug.Log(thing.name);
            if(thing.name=="Spawn Point"){
                spawns.Add(thing);
                //Debug.Log(spawns);
            }
            if(thing.name=="Teacher Spawn Point"){
                teacherSpawns.Add(thing);
                //Debug.Log(spawns);
            }
        }
        SpawnAtRandomSpawnPoint();
    }

    void SpawnAtRandomSpawnPoint(){
        int randomPos;
        while (teacherSpawns.Count>0){
            randomPos = Random.Range(0, teacherSpawns.Count);
            instantiatedObject=Instantiate(teacherPrefab);
            instantiatedObject.name = "Teacher";
            instantiatedObject.transform.SetParent(teacherSpawns[randomPos].transform.parent.transform.parent);
            instantiatedObject.transform.position = teacherSpawns[randomPos].transform.position;
            instantiatedObject.GetComponent<LookAt>().enabled=true;
            teacherSpawns.RemoveAt(randomPos);
        }
        while (spawns.Count>0){
            randomPos = Random.Range(0, spawns.Count);
            if(playerSpawnFlag){
                playerPrefab.transform.position = spawns[randomPos].transform.position;
                playerPrefab.GetComponent<LookAt>().enabled=true;
                playerPrefab.transform.SetParent(spawns[randomPos].transform.parent.transform.parent);
                playerPrefab.name = "Player";
                playerSpawnFlag = false;
                /*instantiatedObject=Instantiate(playerPrefab);
                instantiatedObject.name = "Player";
                playerSpawnFlag = false;
                instantiatedObject.transform.SetParent(spawns[randomPos].transform.parent.transform.parent);
                instantiatedObject.transform.position = spawns[randomPos].transform.position;
                instantiatedObject.GetComponent<LookAt>().enabled=true;*/
                if(SelectedCharacterScript.character==0)
                    spawns[randomPos].GetComponent<WhatIsInSpawn>().isGirl=true;
            }else{
                if(Random.Range(0, 2)==0){
                    instantiatedObject=Instantiate(femaleHumanPrefab);
                    instantiatedObject.name = "Girl";
                    spawns[randomPos].GetComponent<WhatIsInSpawn>().isGirl=true;
                    spawns[randomPos].GetComponent<WhatIsInSpawn>().human=instantiatedObject;
                }    
                else{
                    instantiatedObject=Instantiate(maleHumanPrefab);
                    instantiatedObject.name = "Boy";
                    spawns[randomPos].GetComponent<WhatIsInSpawn>().human=instantiatedObject;
                }    
                humans.Add(instantiatedObject);
                instantiatedObject.transform.SetParent(spawns[randomPos].transform.parent.transform.parent);
                instantiatedObject.transform.position = spawns[randomPos].transform.position;
            }

            spawns.RemoveAt(randomPos);
        }
        //playerPrefab.SetActive(false);
        femaleHumanPrefab.SetActive(false);
        maleHumanPrefab.SetActive(false);
        teacherPrefab.SetActive(false);
    }
}
