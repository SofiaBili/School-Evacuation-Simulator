using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrillHuman : MonoBehaviour
{
    
    SpawnHumans spawnHumansScript;
    [SerializeField] GameObject spawnHumansObject;
    public static bool startEvacFlag = false;

    void Awake(){
        spawnHumansScript = spawnHumansObject.GetComponent<SpawnHumans>();
    }

    void Update(){
        if(startEvacFlag){
            humanStandUp();
        }
    }
    public void humanStandUp(){
        startEvacFlag=false;
        foreach (var pers in spawnHumansScript.humans){
            pers.GetComponent<CapsuleCollider>().enabled=true;
            pers.GetComponent<BoxCollider>().enabled=false;
            pers.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=true;
            pers.GetComponent<Rigidbody>().isKinematic = true; 
            pers.GetComponent<NavMeshControl>().enabled=true;
        }
		NavMeshControl.startNavmesh = true;
        foreach (var pers in spawnHumansScript.humans){
            pers.GetComponent<HumanActions>().FireDrillAction();
        }
    }
}
