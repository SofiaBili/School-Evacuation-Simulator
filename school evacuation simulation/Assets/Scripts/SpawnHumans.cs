using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHumans : MonoBehaviour
{
    [SerializeField] GameObject mapGameObject;
    List<Transform> spawns = new List<Transform>();
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
    }
}
