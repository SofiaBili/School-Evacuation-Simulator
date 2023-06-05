using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
	public GameObject canvas;
	public List<GameObject> hearts;
	public int count=2;
	public static bool removing=false;
	
	void Update(){
		if(removing){
			Process();
		}
	}
	public void Process(){
		removing=false;
		hearts[count].SetActive(false);
		hearts.RemoveAt(count);
		count--;
		if(count==-1) PlayerLost();
    }
    public static void RemoveHeart(){ 
		removing=true;
    }
    public void PlayerLost(){
    }
}