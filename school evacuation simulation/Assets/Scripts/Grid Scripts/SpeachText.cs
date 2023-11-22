using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeachText : MonoBehaviour
{
    public static SpeachText instance;
    public TextMeshProUGUI textComp;

    void Awake()
    {
        //if there is already one
        if(instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetAndShowPanel(string mess){
        gameObject.SetActive(true);
        textComp.text = mess;
        StartCoroutine(HideCoroutine());
    }
   
    IEnumerator HideCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        textComp.text = string.Empty;
    }
}
