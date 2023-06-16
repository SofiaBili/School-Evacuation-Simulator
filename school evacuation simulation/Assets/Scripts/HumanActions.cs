using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanActions : MonoBehaviour
{
    Animator animator;
    private Vector3 targetPos;
    private string currentState;
    private bool fireFlag = false;
    private bool earthquakeFlag = false;

    FireDrillHuman fireDrillHuman;
    [SerializeField] GameObject fireDrillHumanObject;
    public float humanPosX, humanPosZ;
    public bool movementStarted = false;

    void Awake(){
        fireDrillHuman = fireDrillHumanObject.GetComponent<FireDrillHuman>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //StartCoroutine(AfterXSeconds(10));
    }

    // Update is called once per frame
    void Update()
    {
        if(!fireFlag && !earthquakeFlag){
            ChangeAnimationState("Sitting");
        }else if(earthquakeFlag && !fireFlag){
            ChangeAnimationState("Idle");
        }else{
            if(!movementStarted && (Mathf.Abs(gameObject.transform.position.x - humanPosX)>1 || Mathf.Abs(gameObject.transform.position.z - humanPosZ)>1)){
                ChangeAnimationState("Walking");
                movementStarted = true;
            }
        }
        
        targetPos=transform.position;
    }

    public void FireDrillAction(){
        humanPosX = gameObject.transform.position.x;
        humanPosZ = gameObject.transform.position.z;
        fireFlag = true;
    }

    public void EarthquakeDrillAction(){
        earthquakeFlag = true;
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

        yield return new WaitForSeconds(0.1f);
        //gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=true;
        //gameObject.GetComponent<NavMeshControl>().enabled=true;
    }
}
