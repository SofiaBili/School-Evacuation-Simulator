using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHumans : MonoBehaviour
{

    [SerializeField] GameObject maleHumanPrefab;
    [SerializeField] GameObject femaleHumanPrefab;
    [SerializeField] GameObject mapGameObject;
    [SerializeField] GameObject humansGameObject;

    List<Transform> spawns = new List<Transform>();
    GameObject instantiatedObject;
    // Start is called before the first frame update
    void Start() {
        FindAllSpawns();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FindAllSpawns(){
        foreach(Transform thing in mapGameObject.GetComponentsInChildren<Transform>()){
            Debug.Log(thing.name);
            if(thing.name=="Spawn Point"){
                spawns.Add(thing);
                Debug.Log(spawns);
            }
        }
        SpawnAtRandomSpawnPoint();
    }

    void SpawnAtRandomSpawnPoint(){
        int randomPos;
        while (spawns.Count>0){
            randomPos = Random.Range(0, spawns.Count);
            Debug.Log(spawns.Count);
            Debug.Log(randomPos);
            if(Random.Range(0, 2)==0){
                instantiatedObject=Instantiate(femaleHumanPrefab);
                instantiatedObject.name = "Girl";
            }    
            else{
                instantiatedObject=Instantiate(maleHumanPrefab);
                instantiatedObject.name = "Boy";
            }    
            instantiatedObject.transform.SetParent(humansGameObject.transform);
            instantiatedObject.transform.position = spawns[randomPos].transform.position;

            spawns.RemoveAt(randomPos);
        }
    }
}
