using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeClassScript : MonoBehaviour
{
    public Animator earthquakeAnimator;
	public GameObject hitbox1, hitbox2, hitbox3, hitbox4;
	public GameObject floorHitBox;
	public GameObject dustParticles;
	public static bool worriedTeacher = false;
    private string currentState;
    // Start is called before the first frame update
    void Start(){
        earthquakeAnimator = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
			Debug.Log("ppppppppp");
			StartCoroutine(StartEarthquake());
		}
	}
	public IEnumerator StartEarthquake(){
		if(EarthquakeGuideScript.guideIsOver){
        	yield return new WaitForSeconds (10f);
			ChangeAnimationState("earthquake");
			worriedTeacher = true;
        	yield return new WaitForSeconds (5f);
			dustParticles.SetActive(true);
		}
	}
	public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!earthquakeAnimator.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            earthquakeAnimator.Play(newState);
    }
}
