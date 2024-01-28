using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public TextboxHandler textbox;
    
    public GameObject[] objects;

    public List<GameObject> spawnedObjects = new();

    public void SpawnObject(int objectIndex, Vector2 position) => spawnedObjects.Add(Instantiate(objects[objectIndex], position, Quaternion.identity));

    public void DestroyObj(GameObject obj)
    {
        spawnedObjects.Remove(obj);
        Destroy(obj);
    }
}
