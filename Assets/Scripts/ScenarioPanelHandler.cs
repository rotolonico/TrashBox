using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScenarioPanelHandler : MonoBehaviour
{
    public GameObject scenarioPrefab;
    public GameObject scenarioContainer;
    
    public void OnEnable() => RetriveScenarios();

    public async void RetriveScenarios()
    {
        var responseTask = await FirebaseDatabase.Get<Dictionary<string, Scenario>>("scenarios");
        var response = responseTask.data;
        foreach (var scenarioData in response)
        {
            var scenario = Instantiate(scenarioPrefab, transform.position, Quaternion.identity);
            scenario.transform.SetParent(scenarioContainer.transform);
            
            var scenarioHandler = scenario.GetComponent<ScenarioHandler>();
            scenarioHandler.nameText.text = scenarioData.Value.name;
            scenarioHandler.authorText.text = scenarioData.Value.author;
            scenarioHandler.rating.sprite = scenarioHandler.ratingSprites[scenarioData.Value.ratings.Values.Sum() / scenarioData.Value.ratings.Count];
        }
    }
    
    public void ClosePanel() => gameObject.SetActive(false);
}
