using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        scenario.author = authorText.text;
        scenario.objects = GetComponent<ObjectSpawner>().spawnedObjects.ToList().Select(o => new GenericObject()
        {
            objId = o.GetComponent<EditorObjectHandler>().objectId,
            x = o.transform.position.x,
            y = o.transform.position.y
        }).ToList();
        
        UploadScenario(scenario);
    }

    public async void UploadScenario(Scenario scenario)
    {
        await FirebaseDatabase.Push("scenarios", scenario);
        ReturnToMenu();
    }
    
    public void ReturnToMenu() => SceneManager.LoadScene("Menu");
}
