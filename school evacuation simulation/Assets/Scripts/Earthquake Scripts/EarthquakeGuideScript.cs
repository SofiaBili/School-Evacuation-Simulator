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

    public AudioSource talkingSound1;
    public AudioSource talkingSound2;
    // Start is called before the first frame update
    void Start()
    {
        personGirl.GetComponent<PlayerMovement>().StopMovement();
        personBoy.GetComponent<PlayerMovement>().StopMovement();
        cameraPersonGirl.GetComponent<RotatePlayer>().enabled = false;
        cameraPersonBoy.GetComponent<RotatePlayer>().enabled = false;
        cameraPersonGirl.GetComponent<PlayerZoom>().enabled = false;
        cameraPersonBoy.GetComponent<PlayerZoom>().enabled = false;
    }

    public void End(){
        talkingSound1.Stop();
        talkingSound2.Stop();
        StopAllCoroutines();

        personGirl.GetComponent<PlayerMovement>().StartMovement();
        personBoy.GetComponent<PlayerMovement>().StartMovement();
        cameraPersonGirl.GetComponent<RotatePlayer>().enabled = true;
        cameraPersonBoy.GetComponent<RotatePlayer>().enabled = true;
        cameraPersonGirl.GetComponent<PlayerZoom>().enabled = true;
        cameraPersonBoy.GetComponent<PlayerZoom>().enabled = true;

        Destroy(room);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
