using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfQuestionHitboxScript : MonoBehaviour
{
    public List<GameObject> hitboxes = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddHitboxToList(GameObject hitbox){
        hitboxes.Add(hitbox);
    }
}
