using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeGuideScript : MonoBehaviour
{
    public GameObject room;

    public static bool guideIsOver = false;
    void Awake(){
		  guideIsOver = false;
    }
    // Start is called before the first frame update
    void Start(){
		  StartCoroutine(StartGuide());
    }
    public void End(){
      StopAllCoroutines();

      Destroy(room);
      LookAt.GuideEnd();
      guideIsOver = true;
      ToggleCanvas.ToggleOneCanvas();
    }
    
    public IEnumerator StartGuide(){
      yield return new WaitForSeconds (40f);
      End();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
