using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleQuestionCanvas : MonoBehaviour
{
    [SerializeField] GameObject canvasMultiple1;
    [SerializeField] GameObject canvasMultiple2;
    [SerializeField] GameObject canvasTrueFalse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableRandomCanvas(){
        int randomCanvas = Random.Range(0, 2);
        if(randomCanvas==0)
            canvasMultiple1.SetActive(true);
        else if(randomCanvas==1)
            canvasMultiple2.SetActive(true);
        else
            canvasTrueFalse.SetActive(true);
    }
}
