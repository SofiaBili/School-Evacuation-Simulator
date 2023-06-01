using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCharacterScript : MonoBehaviour
{
    public GameObject boy;
    public GameObject girl;
    // Start is called before the first frame update
    void Start()
    {
        boy.SetActive(false);
        girl.SetActive(false);
        if(SelectedCharacterScript.character==0){
            girl.SetActive(true);
        }
        else if(SelectedCharacterScript.character==1){
            boy.SetActive(true);
        }
    }

}
