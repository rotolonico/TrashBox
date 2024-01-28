using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayHandler : MonoBehaviour
{
    public static Scenario currentScenario;

    public ObjectSpawner objectSpawner;

    private void Start() =>
        currentScenario.objects.ForEach(obj => objectSpawner.SpawnObject(obj.objId, new Vector2(obj.x, obj.y)));
    
    public void BackToMenu() => SceneManager.LoadScene("Menu");
}