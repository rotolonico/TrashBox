using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneHandler : MonoBehaviour
{
    public Canvas mainCanvas;
    public GameObject loreText;

    public AudioSource trashAudioSource;
    public Animator trashAnimator;

    public GameObject levelPanel;
    
    public void OpenLevelSelect() => levelPanel.SetActive(true);
    
    public void CloseLevelSelect() => levelPanel.SetActive(false);

    public void Quit() => Application.Quit();
    
    public void OpenEditor() => SceneManager.LoadScene("Editor");
    
    public void OpenLoreCanvas()
    {
        trashAudioSource.Play();
        loreText.SetActive(true);
        trashAnimator.Play("LoreAnimation");
        mainCanvas.enabled = false;
        StartCoroutine(WaitForAnimation());
    }
    
    public void OpenMainCanvas()
    {
        trashAudioSource.Stop();
        loreText.SetActive(false);
        mainCanvas.enabled = true;
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(14f);
        OpenMainCanvas();
    }
    
    
}
