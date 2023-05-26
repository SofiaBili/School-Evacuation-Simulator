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
    public GameObject canvasPointLevelB;

    public TextMeshProUGUI textUpRight;
    public TextMeshProUGUI textUpLeft;
    public TextMeshProUGUI textDownRight;
    public TextMeshProUGUI textDownLeft;
    public Camera guideCam;
    public Camera animationCam1;
    
    public GameObject room;
    public GameObject personGirl;
    public GameObject personBoy;
    public Camera cameraPersonGirl;
    public Camera cameraPersonBoy;
    TimerScript timerG;
    TimerScript timerB;
    bool stop = false;

    // Start is called before the first frame update
    void Start(){
        canvasPointLevelG.SetActive(false);
        canvasPointLevelG.SetActive(true);
        canvasPointLevelB.SetActive(false);
        canvasPointLevelB.SetActive(true);
        timerG = personGirl.transform.Find("Point Level Canvas").GetComponent<TimerScript>();
        timerB = personBoy.transform.Find("Point Level Canvas").GetComponent<TimerScript>();
        
        Plan();
    }
    public void End(){
        stop = true;
        StopAllCoroutines();
        canvasUpRight.SetActive(false);
        canvasUpLeft.SetActive(false);
        canvasDownRight.SetActive(false);
        canvasDownLeft.SetActive(false);

        personGirl.GetComponent<PlayerMovement>().StartMovement();
        personBoy.GetComponent<PlayerMovement>().StartMovement();
        cameraPersonGirl.GetComponent<RotatePlayer>().enabled = true;
        cameraPersonBoy.GetComponent<RotatePlayer>().enabled = true;
        cameraPersonGirl.GetComponent<PlayerZoom>().enabled = true;
        cameraPersonBoy.GetComponent<PlayerZoom>().enabled = true;

        Destroy(room);
        timerG.SetTimer(180);
        timerB.SetTimer(180);
        timerG.AdjustWater();
        timerB.AdjustWater();
    }
    void Plan(){
        personGirl.GetComponent<PlayerMovement>().StopMovement();
        personBoy.GetComponent<PlayerMovement>().StopMovement();
        cameraPersonGirl.GetComponent<RotatePlayer>().enabled = false;
        cameraPersonBoy.GetComponent<RotatePlayer>().enabled = false;
        cameraPersonGirl.GetComponent<PlayerZoom>().enabled = false;
        cameraPersonBoy.GetComponent<PlayerZoom>().enabled = false;
        //PauseGame();
		StartCoroutine(StartGuide());
    }
    
    public IEnumerator StartGuide(){
        if(!stop){
            canvasUpLeft.SetActive(true);
            textUpLeft.text = "Καλώς ήρθες στην πίστα: Πλυμμήρα! Σε αυτό το μέρος υπάρχουν κρυμμένες ερωτήσεις στις αίθουσες. Μπορείς να τις βρεις όλες πριν τελειώσει ο χρόνος;";
            yield return new WaitForSeconds (8f);

        
            canvasUpLeft.SetActive(false);
            yield return new WaitForSeconds (0.1f);
            canvasDownLeft.SetActive(true);
            textDownLeft.text = "Στα δωμάτια με τις ερωτήσεις θα σου εμφανίζεται στην οθόνη σου ένα κουμπί που θα σου λέει \" Πάτησε \"Q\" για να απαντήσεις σε μιά ερώτηση\"";
            yield return new WaitForSeconds (10f);
            textDownLeft.text = "Κάτω αριστερά θα μπορείς να βλέπεις τον χρόνο που σου μένει για να ολοκληρώσεις την πίστα.";
            yield return new WaitForSeconds (8f);
        
            canvasDownLeft.SetActive(false);
            yield return new WaitForSeconds (0.1f);
            canvasUpLeft.SetActive(true);
            textUpLeft.text = "Προσοχή! Μπορείς να πατήσεις το x πάνω δεξιά σε κάποια ερώτηση σε περίπτωση που δεν την ξέρεις.";
            yield return new WaitForSeconds (10f);
            textUpLeft.text = "Υπάρχει η πιθανότητα να σου εμφανιστεί άλλη ερώτηση όταν ξαναδοκιμάσεις. Έτσι δεν θα χάσεις πόντους.";
            yield return new WaitForSeconds (10f);
            canvasUpLeft.SetActive(false);
            canvasUpRight.SetActive(true);
            textUpRight.text = "Ο χάρτης αυτός δίπλα μου θα σε βοηθήσει να μετακινηθείς πιο εύκολα μέσα στο σχολείο.";
            yield return new WaitForSeconds (10f);
        
            canvasUpRight.SetActive(false);
            yield return new WaitForSeconds (0.1f);
            canvasDownRight.SetActive(true);
            textDownRight.text = "Για κάθε λάθος απάντηση η μπάρα σου θα αδειάζει και για κάθε σωστή θα γεμίζει!";
            yield return new WaitForSeconds (10f);
            textDownRight.text = "Πρέπει να απαντήσεις σωστά τουλάχιστον 10 ερωτήσεις, αλλιώς αν ξεμείνεις από χρόνο ή από ερωτήσεις θα χάσεις.";
            yield return new WaitForSeconds (10f); 
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