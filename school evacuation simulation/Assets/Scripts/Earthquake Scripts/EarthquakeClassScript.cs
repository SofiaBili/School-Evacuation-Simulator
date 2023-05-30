using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeClassScript : MonoBehaviour
{
    public Animator earthquakeAnimation;
	public GameObject hitbox1, hitbox2, hitbox3, hitbox4;


    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(StartEarthquake());
    }
	public IEnumerator StartEarthquake(){
		if(EarthquakeGuideScript.guideIsOver){
        	yield return new WaitForSeconds (10f);
			earthquakeAnimation.Play(0);
		}
	}
}
