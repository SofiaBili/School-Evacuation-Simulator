using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerScript : MonoBehaviour
{

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject mapGameObject;

    List<Transform> spawns = new List<Transform>();
    // Start is called before the first frame update
    void Start() {
        FindAllSpawns();
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
            //Debug.Log(spawns.Count);
            //Debug.Log(randomPos);
            playerPrefab.transform.position = spawns[randomPos].transform.position;
            //instantiatedObject.GetComponent<LookAt>().enabled=false;
            spawns.RemoveAt(randomPos);
        }
    }
}
