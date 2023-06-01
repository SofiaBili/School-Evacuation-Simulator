using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectedCharacterScript : MonoBehaviour
{
    //Character == -1 is Nothing set
    //Character == 0 is Girl
    //Character == 1 is Boy

    public static int character;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        character=-1;
    }

    public void BoyCharacter(){
        character=1;
        gameObject.SetActive(true);
    }

    public void GirlCharacter(){
        character=0;
        gameObject.SetActive(true);
    }

    public void StartGame(){
        if(ChoosenEvacuationTypeScript.evacuationType==0){
            SceneManager.LoadScene("FireDrillScene");
        }
        else if(ChoosenEvacuationTypeScript.evacuationType==1){
            SceneManager.LoadScene("EarthquakeDrillScene");
        }
        else if(ChoosenEvacuationTypeScript.evacuationType==2){
            SceneManager.LoadScene("FloodDrillScene");
        }
    }
}
