using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioHandler : MonoBehaviour
{
    public Sprite[] ratingSprites;
    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI authorText;
    public Image rating;
    
    public string id;
    public Scenario scenario;

    public void Play()
    {
        if (id == "test_scenario")
        {
            SceneManager.LoadScene("TestScenario");
        }
        else
        {
            PlayHandler.currentScenario = scenario;
            SceneManager.LoadScene("Play");
        }
    }
}
