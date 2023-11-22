using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosenEvacuationTypeScript : MonoBehaviour
{
    //Evacuation Type == -1 is Nothing set
    //Evacuation Type == 0 is Fire
    //Evacuation Type == 1 is EearthQuake
    //Evacuation Type == 2 is Flood

    public static int evacuationType;

    // Start is called before the first frame update
    void Start()
    {
        transform.gameObject.SetActive(false);
        evacuationType=-1;
    }

    public void FireDrillEvent(){
        evacuationType=0;
        gameObject.SetActive(true);
    }

    public void EarthquakeEvent(){
        evacuationType=1;
        gameObject.SetActive(true);
    }

    public void FloodEvent(){
        evacuationType=2;
        gameObject.SetActive(true);
    }

    public void CharacterSelectionScene(){
        SceneManager.LoadScene("ChooseCharacter");
    }
}
