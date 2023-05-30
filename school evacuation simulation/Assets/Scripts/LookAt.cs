using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    GameObject target;
    GameObject targetParent;
    public string objectToFind;
    bool oneTimeFlag = true;
    public bool isPlayerFlag = false;
    static bool guideEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static void GuideEnd(){
        guideEnd=true;
    }
    // Update is called once per frame
    void Update()
    {
        if(oneTimeFlag && guideEnd){
            if(!isPlayerFlag){
                targetParent = gameObject.transform.parent.gameObject;
            }else{
                targetParent = gameObject.transform.parent.transform.parent.gameObject;
            }
            target = targetParent.transform.Find(objectToFind).gameObject;
            transform.LookAt(target.transform);
            transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);
            oneTimeFlag = false;
        }

    }
}
