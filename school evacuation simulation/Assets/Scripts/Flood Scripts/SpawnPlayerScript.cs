using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerScript : MonoBehaviour
{

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject mapGameObject;

    List<Transform> spawns = new List<Transform>();
    
    /*void Update() {
        if(MapCreation.mapIsFinished){
            FindAllSpawns();
            MapCreation.mapIsFinished = false;
        }
    }

    void FindAllSpawns(){
        foreach(Transform thing in mapGameObject.GetComponentsInChildren<Transform>()){
            //Debug.Log(thing.name);
            if(thing.name=="Spawn Point"){
                spawns.Add(thing);
                //Debug.Log(spawns);
            }
        }
        SpawnAtRandomSpawnPoint();
    }

    void SpawnAtRandomSpawnPoint(){
        int randomPos;
        if(spawns.Count>0){
            randomPos = Random.Range(0, spawns.Count);
            Debug.Log(spawns.Count);
            Debug.Log(randomPos);
            Debug.Log(playerPrefab.transform.position);
            Debug.Log(spawns[randomPos].transform.position);
            playerPrefab.transform.localPosition = spawns[randomPos].transform.localPosition;
            Debug.Log(playerPrefab.transform.position);
            //instantiatedObject.GetComponent<LookAt>().enabled=false;
            spawns.RemoveAt(randomPos);
        }
    }*/
}
