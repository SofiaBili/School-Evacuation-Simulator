using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> placedGameObjects = new();

    public int PlaceObject(GameObject prefab, Vector3 position)
    {
        GameObject newObject = Instantiate(prefab);
        newObject.transform.position = position;
        placedGameObjects.Add(newObject);
        return placedGameObjects.Count - 1;
    }

    public void RemoveObjectAt(int gameObjectIndex)
    {
        if (placedGameObjects.Count <= gameObjectIndex || placedGameObjects[gameObjectIndex] == null)
            return;
        Destroy(placedGameObjects[gameObjectIndex]);
        placedGameObjects[gameObjectIndex] = null;
    }
    public void RotateObjectAt(int gameObjectIndex)
    {
        if (placedGameObjects.Count <= gameObjectIndex || placedGameObjects[gameObjectIndex] == null)
            return;
        //placedGameObjects[gameObjectIndex].transform.Rotate(0.0f, 0.0f, 90f, Space.World);
        Debug.Log(placedGameObjects[gameObjectIndex]);
        Debug.Log(placedGameObjects[gameObjectIndex].transform.GetChild(0));
        placedGameObjects[gameObjectIndex].transform.GetChild(0).transform.Rotate(0.0f, 90f, 0f, Space.World);
    }
}