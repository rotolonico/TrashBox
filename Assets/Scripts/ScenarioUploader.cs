using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScenarioUploader : MonoBehaviour
{
    public TMP_InputField nameText;
    public TMP_InputField authorText;
    
    public void PrepareAndUploadScenario()
    {
        var scenario = new Scenario
        {
            name = nameText.text
        };
        scenario.name = authorText.text;
        scenario.objects = GetComponent<ObjectSpawner>().spawnedObjects.ToList().Select(o => new GenericObject()
        {
            x = o.transform.position.x,
            y = o.transform.position.y
        }).ToList();
        
        UploadScenario(scenario);
    }
    
    public void UploadScenario(Scenario scenario)
    {
        FirebaseDatabase.Push("scenarios", scenario);
    }

    public void UploadScore(int score, string scenarioId)
    {
        FirebaseDatabase.Push($"scenarios/{scenarioId}", score);
    }
}
