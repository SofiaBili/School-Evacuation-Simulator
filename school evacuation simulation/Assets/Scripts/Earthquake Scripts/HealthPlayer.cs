using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
	public GameObject canvas;
	public List<GameObject> hearts;
	public static int count=2;
	public static bool removing=false;
	public static int rightAns = 0;
	public static int totalAns = 13;
	public static int totalFireAns = 10;
	public string sceneName;
	public bool isEarthquake=true;
	public static bool staticIsEarthquake;
	void Start(){
		staticIsEarthquake = isEarthquake;
	}
	void Update(){
		if(removing){
			Process();
		}
	}
	public static void RightAnswer(){
        rightAns++;
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
        SceneManager.LoadScene(sceneName);
    }
	
    public static int GetRightAns(){
        return rightAns;
    }
	public static int GetTotalAns(){
        if(staticIsEarthquake) return totalAns;
		else return totalFireAns;
    }
	
	public static int GetWrongAns(){
        return 2-count;
    }
}