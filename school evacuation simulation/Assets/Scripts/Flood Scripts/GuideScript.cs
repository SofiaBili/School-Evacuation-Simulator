using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GuideScript : MonoBehaviour
{
    public GameObject canvasUpRight;
    public GameObject canvasUpLeft;
    public GameObject canvasDownRight;
    public GameObject canvasDownLeft;
    public GameObject canvasPointLevelG;

    public TextMeshProUGUI textUpRight;
    public TextMeshProUGUI textUpLeft;
    public TextMeshProUGUI textDownRight;
    public TextMeshProUGUI textDownLeft;
    public Camera guideCam;
    public Camera animationCam1;
    
    public GameObject room;
    public GameObject personGirl;
    public Camera cameraPersonGirl;
    TimerScript timerG;
    bool stop = false;
    public AudioSource talkingSound1;
    public AudioSource talkingSound2;

    // Start is called before the first frame update
    void Start(){
        canvasPointLevelG.SetActive(false);
        canvasPointLevelG.SetActive(true);
        timerG = personGirl.transform.Find("Point Level Canvas").GetComponent<TimerScript>();
        
        Plan();
    }
    public void End(){
        talkingSound1.Stop();
        talkingSound2.Stop();
        stop = true;
        StopAllCoroutines();
        canvasUpRight.SetActive(false);
        canvasUpLeft.SetActive(false);
        canvasDownRight.SetActive(false);
        canvasDownLeft.SetActive(false);

        personGirl.GetComponent<PlayerMovement>().StartMovement();
        cameraPersonGirl.GetComponent<RotatePlayer>().enabled = true;
        cameraPersonGirl.GetComponent<PlayerZoom>().enabled = true;

        Destroy(room);
        timerG.SetTimer(600);
        timerG.AdjustWater();
    }
    void Plan(){
        personGirl.GetComponent<PlayerMovement>().StopMovement();
        cameraPersonGirl.GetComponent<RotatePlayer>().enabled = false;
        cameraPersonGirl.GetComponent<PlayerZoom>().enabled = false;
        //PauseGame();
		StartCoroutine(StartGuide());
    }
    
    public IEnumerator StartGuide(){
        if(!stop){
            talkingSound1.Play();
            yield return new WaitForSeconds (8.1f);
            talkingSound1.Stop();
            canvasUpLeft.SetActive(true);
            talkingSound2.Play();
            textUpLeft.text = "Καλώς ήρθες στην πίστα: πλημμύρα! Σε αυτό το μέρος υπάρχουν κρυμμένες ερωτήσεις στις αίθουσες. Μπορείς να τις βρεις όλες πριν τελειώσει ο χρόνος;";
            yield return new WaitForSeconds (8f);
            talkingSound2.Stop();
        
            canvasUpLeft.SetActive(false);
            yield return new WaitForSeconds (0.1f);
            canvasDownLeft.SetActive(true);
            talkingSound1.Play();
            textDownLeft.text = "Στα δωμάτια με τις ερωτήσεις θα σου εμφανίζεται στην οθόνη σου ένα κουμπί που θα σου λέει \" Πάτησε \"Q\" για να απαντήσεις σε μια ερώτηση\"";
            yield return new WaitForSeconds (5.3f);
            talkingSound1.Stop();
            talkingSound2.Play();
            textDownLeft.text = "Κάτω αριστερά θα μπορείς να βλέπεις τον χρόνο που σου μένει για να ολοκληρώσεις την πίστα.";
            yield return new WaitForSeconds (5.3f);
            talkingSound2.Stop();
        
            canvasDownLeft.SetActive(false);
            yield return new WaitForSeconds (0.1f);
            canvasUpLeft.SetActive(true);
            talkingSound1.Play();
            textUpLeft.text = "Προσοχή! Μπορείς να πατήσεις το x πάνω δεξιά σε κάποια ερώτηση σε περίπτωση που δεν την ξέρεις.";
            yield return new WaitForSeconds (8f);
            talkingSound1.Stop();
            talkingSound2.Play();
            textUpLeft.text = "Υπάρχει η πιθανότητα να σου εμφανιστεί άλλη ερώτηση όταν ξαναδοκιμάσεις. Έτσι δεν θα χάσεις πόντους.";
            yield return new WaitForSeconds (5.3f);
            talkingSound2.Stop();
            canvasUpLeft.SetActive(false);
            canvasUpRight.SetActive(true);
            talkingSound1.Play();
            textUpRight.text = "Ο χάρτης αυτός δίπλα μου θα σε βοηθήσει να μετακινηθείς πιο εύκολα μέσα στο σχολείο.";
            yield return new WaitForSeconds (5.3f);
            talkingSound1.Stop();
        
            canvasUpRight.SetActive(false);
            yield return new WaitForSeconds (0.1f);
            canvasDownRight.SetActive(true);
            talkingSound2.Play();
            textDownRight.text = "Για κάθε λάθος απάντηση η μπάρα σου θα αδειάζει και για κάθε σωστή θα γεμίζει!";
            yield return new WaitForSeconds (5.3f);
            talkingSound2.Stop();
            talkingSound1.Play();
            textDownRight.text = "Πρέπει να απαντήσεις σωστά τουλάχιστον 10 ερωτήσεις, αλλιώς αν ξεμείνεις από χρόνο ή από ερωτήσεις θα χάσεις.";
            yield return new WaitForSeconds (5.3f);
            talkingSound1.Stop();
            canvasDownRight.SetActive(false);
            yield return new WaitForSeconds (3f);
            animationCam1.targetDisplay = 2;
            
            canvasDownRight.SetActive(false);
            End();
        }
	}
    // Update is called once per frame
    void Update(){
        
    }
    void PauseGame(){
        Time.timeScale = 0;
    }
    void ResumeGame(){
        Time.timeScale = 1;
    }
}