using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeGuideScript : MonoBehaviour
{
    public GameObject room;

    public GameObject personGirl;
    public GameObject personBoy;
    public Camera cameraPersonGirl;
    public Camera cameraPersonBoy;

    // Start is called before the first frame update
    void Start()
    {
        personGirl.GetComponent<PlayerMovement>().StopMovement();
        personBoy.GetComponent<PlayerMovement>().StopMovement();
        cameraPersonGirl.GetComponent<RotatePlayer>().enabled = false;
        cameraPersonBoy.GetComponent<RotatePlayer>().enabled = false;
        cameraPersonGirl.GetComponent<PlayerZoom>().enabled = false;
        cameraPersonBoy.GetComponent<PlayerZoom>().enabled = false;
		StartCoroutine(StartGuide());
    }

    public void End(){
        StopAllCoroutines();

        personGirl.GetComponent<PlayerMovement>().StartMovement();
        personBoy.GetComponent<PlayerMovement>().StartMovement();
        cameraPersonGirl.GetComponent<RotatePlayer>().enabled = true;
        cameraPersonBoy.GetComponent<RotatePlayer>().enabled = true;
        cameraPersonGirl.GetComponent<PlayerZoom>().enabled = true;
        cameraPersonBoy.GetComponent<PlayerZoom>().enabled = true;

        Destroy(room);
        LookAt.GuideEnd();
    }
    
    public IEnumerator StartGuide(){
        yield return new WaitForSeconds (36f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
