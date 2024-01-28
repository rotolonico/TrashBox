using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneHandler : MonoBehaviour
{
    public GameObject levelPanel;
    
    public void OpenLevelSelect() => levelPanel.SetActive(true);

    public void Quit() => Application.Quit();
}
