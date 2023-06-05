using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshControl : MonoBehaviour
{
    public NavMeshAgent agent;
    public static bool startNavmesh = false;
    [SerializeField] GameObject mapGameObject;
    [SerializeField] List<Transform> doors;
    public Transform closestDoor;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.enabled = false;
        foreach(Transform thing in mapGameObject.GetComponentsInChildren<Transform>()){
            if(thing.name.Contains("Transport")){
                doors.Add(thing);
            }
        }
        closestDoor=GetClosestDoor();
        
    }
    public void EnableNavMeshAgent(){
        
    }
    // Update is called once per frame
    void Update(){
        if(startNavmesh){
            agent.SetDestination(closestDoor.position);
        }
    }
    public static void StartNavmesh(){
        startNavmesh = true;
    }
    Transform GetClosestDoor(){
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform potentialTarget in doors){
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr){
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }
}
