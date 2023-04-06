using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    GameObject target;
    GameObject targetParent;
    // Start is called before the first frame update
    void Start()
    {
        targetParent = gameObject.transform.parent.gameObject;
        target = targetParent.transform.Find("Board").gameObject;
        //Debug.Log(gameObject.transform.parent.name);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);
    }
}
