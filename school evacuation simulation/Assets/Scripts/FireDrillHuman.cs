using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrillHuman : MonoBehaviour
{
    
    SpawnHumans spawnHumansScript;
    [SerializeField] GameObject spawnHumansObject;

    void Awake(){
        spawnHumansScript = spawnHumansObject.GetComponent<SpawnHumans>();
    }

    public void humanStandUp(){
        foreach (var pers in spawnHumansScript.humans){
            /*if(pers.transform.rotation.y<100)
                pers.transform.position = pers.transform.position + new Vector3(-1.3f, 0, 0);
            else
                pers.transform.position = pers.transform.position + new Vector3(+1.3f, 0, 0);*/
            pers.transform.localPosition =  pers.transform.localPosition + new Vector3(0, 0, -1.3f);
            pers.GetComponent<CapsuleCollider>().enabled=true;
            pers.GetComponent<BoxCollider>().enabled=false;
            pers.GetComponent<HumanActions>().FireDrillAction();

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
