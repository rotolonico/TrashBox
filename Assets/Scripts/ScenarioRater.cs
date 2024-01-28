using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioRater : MonoBehaviour
{
    public void UploadScore(int score, string scenarioId)
    {
        FirebaseDatabase.Push($"scenarios/{scenarioId}/ratings", score);
    }
}
