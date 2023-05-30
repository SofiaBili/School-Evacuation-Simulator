using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshControl : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] GameObject wayPoint;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;

        // Invoke is used as a workaround for enabling NavMeshAgent on NavMeshSurface
        Invoke("EnableNavMeshAgent", 35f);
        
    }
    private void EnableNavMeshAgent ()
    {
        agent.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
            //Ray movePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if(Physics.Raycast(movePos, out var hitInfo)){
           // agent.SetDestination(wayPoint.transform.position);
            //}
    }
}
