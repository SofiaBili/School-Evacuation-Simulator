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

    public TextMeshProUGUI textUpRight;
    public TextMeshProUGUI textUpLeft;
    public TextMeshProUGUI textDownRight;
    public TextMeshProUGUI textDownLeft;

    // Start is called before the first frame update
    void Start(){
        Plan();
    }

    void Plan(){
        //PauseGame();
		StartCoroutine(StartGuide());
    }
    
    private IEnumerator StartGuide(){
        canvasUpLeft.SetActive(true);
        textUpLeft.text = "Καλώς ήρθες στην πίστα: Πλυμμήρα! Σε αυτό το μέρος υπάρχουν κρυμμένες ερωτήσεις στις αίθουσες. Μπορείς να τις βρεις όλες πριν τελειώσει ο χρόνος;";
		yield return new WaitForSeconds (10f);

    
        canvasUpLeft.SetActive(false);
		yield return new WaitForSeconds (0.1f);
        canvasDownLeft.SetActive(true);
        textDownLeft.text = "Στα δωμάτια με τις ερωτήσεις θα σου εμφανίζεται στην μέση της οθόνης σου ένα κουμπί που θα σου λέει \" Πάτα \"Q\" για να απαντήσεις σε μιά ερώτηση\"";
		yield return new WaitForSeconds (10f);
        textDownLeft.text = "Κάτω αριστερά θα μπορείς να βλέπεις τον χρόνο που σου μένει για να ολοκληρώσεις την πίστα.";
		yield return new WaitForSeconds (10f);
    
        canvasDownLeft.SetActive(false);
		yield return new WaitForSeconds (0.1f);
        canvasUpRight.SetActive(true);
        textUpRight.text = "Προσοχή! Μπορείς να πατήσεις το x πάνω δεξιά σε κάποια ερώτηση σε περίπτωση που δεν την ξέρεις.";
		yield return new WaitForSeconds (10f);
        textUpRight.text = "Υπάρχει η πιθανότητα να σου εμφανιστεί άλλη ερώτηση όταν ξαναδοκιμάσεις. Έτσι δεν θα χάσεις πόντους.";
		yield return new WaitForSeconds (10f);
        textUpRight.text = "Ο χάρτης αυτός δίπλα μου θα σε βοηθήσει να μετακινηθείς πιο εύκολα μέσα στο σχολείο.";
		yield return new WaitForSeconds (10f);
     
        canvasUpRight.SetActive(false);
		yield return new WaitForSeconds (0.1f);
        canvasDownRight.SetActive(true);
        textDownRight.text = "Για κάθε λάθος απάντηση η μπάρα σου θα αδειάζει και για κάθε σωστή θα γεμίζει!";
		yield return new WaitForSeconds (10f);
        textDownRight.text = "Πρέπει να απαντήσεις σωστά τουλάχιστον 10 ερωτήσεις, αλλιώς αν ξεμείνεις από χρόνο ή από ερωτήσεις θα χάσεις.";
		yield return new WaitForSeconds (10f); 
        
        canvasDownRight.SetActive(false);
        ResumeGame();
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