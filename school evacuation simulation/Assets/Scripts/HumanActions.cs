using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanActions : MonoBehaviour
{
    Animator animator;
    private Vector3 targetPos;
    private string currentState;
    private bool fireFlag = false;

    FireDrillHuman fireDrillHuman;
    [SerializeField] GameObject fireDrillHumanObject;

    void Awake(){
        fireDrillHuman = fireDrillHumanObject.GetComponent<FireDrillHuman>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AfterXSeconds(10));
    }

    // Update is called once per frame
    void Update()
    {
        if(!fireFlag){
            ChangeAnimationState("Sitting");
        }
        else{
            // if ( Vector3.Distance(targetPos, transform.position) > 1.0 ){
            //         ChangeAnimationState("Walking");
            // }
            // else{
            //     ChangeAnimationState("Walking");
            // }   
            ChangeAnimationState("Walking");
        }
        targetPos=transform.position;
    }

    public void FireDrillAction(){
        fireFlag = true;
    }

    public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName(currentState)){
            animator.Play(newState);
        }
    }
 
    IEnumerator AfterXSeconds(int secs){
        yield return new WaitForSeconds(secs);

        gameObject.transform.localPosition =  gameObject.transform.localPosition + new Vector3(0, 0, -1.3f);
        gameObject.GetComponent<CapsuleCollider>().enabled=true;
        gameObject.GetComponent<BoxCollider>().enabled=false;
        FireDrillAction();

        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=true;
        gameObject.GetComponent<NavMeshControl>().enabled=true;
        Debug.Log("daw");
    }
}
