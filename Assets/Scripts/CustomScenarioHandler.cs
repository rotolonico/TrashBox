using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomScenarioHandler : MonoBehaviour
{
    public ScenarioRater scenarioRater;
    
    public SoundsPlayer soundsPlayer;
    public TextboxHandler textboxHandler;

    public GameObject itemPanel;

    public Image switchImage;
    public Sprite switchOnSprite;
    public Sprite switchOffSprite;
    
    public Animator lightAnimator;

    public GameObject pausePanel;
    public Image blackPanel;

    public GameObject pokeballObj;
    
    public GameObject spaghetObj;
    public Image spaghetImage;

    public GameObject ratingPanel;

    public bool isSwitchOffDone;
    public bool isBreakDone;
    public bool isPokeballDone;
    public bool isSpaghetDone;
    
    public void OpenRatingPanel() => ratingPanel.SetActive(true);

    public void CloseRatingPanel() => ratingPanel.SetActive(false);

    public void OnClickBlack()
    {
        soundsPlayer.PlaySound(1);
        lightAnimator.Play("MoveUp");
        blackPanel.enabled = false;
        textboxHandler.ClosePanel();
    }

    public void OnClickPause()
    {
        soundsPlayer.PlaySound(2);
        pausePanel.SetActive(false);
        isBreakDone = true;
    }

    public void OnClickPalBall()
    {
        itemPanel.SetActive(false);
        pokeballObj.SetActive(true);
        soundsPlayer.PlaySound(4);
        switchImage.enabled = false;
        StartCoroutine(WaitForCatch());
    }
    
    public void OnClickSpaghet()
    {
        itemPanel.SetActive(false);
        spaghetObj.SetActive(true);
        soundsPlayer.PlaySound(6);
        StartCoroutine(WaitForSpaghet());
    }
    
    public void OnClickSwitch()
    {
        itemPanel.SetActive(false);
        textboxHandler.TextBoxPrompt("Breaker", new[] { "Switch off", "Take a break-er", "Use item" }, o =>
        {
            // Spegni
            if (o == 0)
            {
                soundsPlayer.PlaySound(0);
                lightAnimator.Play("MoveDown");
                switchImage.sprite = switchImage.sprite == switchOnSprite ? switchOffSprite : switchOnSprite;
                StartCoroutine(WaitForBlack());
            } else if (o == 1) // Interrompi
            {
                soundsPlayer.PlaySound(3);
                pausePanel.SetActive(true);
            } else if (o == 2) // Usa Item
            {
                itemPanel.SetActive(true);
            }
        });
    }

    private IEnumerator WaitForBlack()
    {
        yield return new WaitForSeconds(0.3f);
        blackPanel.enabled = true;
        textboxHandler.TextBoxPrompt("I can't see anything...", new string[]{}, o =>
        {
        }, true);
        yield return new WaitForSeconds(0.3f);
        isSwitchOffDone = true;
    }

    private IEnumerator WaitForCatch()
    {
        yield return new WaitForSeconds(2);
        soundsPlayer.PlaySound(5);
        textboxHandler.TextBoxPrompt("You caught the BREAKER! It is evolving...", new string[]{"Ok"}, o =>
        {
            var rectTransform = switchImage.GetComponent<RectTransform>();
            var oldScale = rectTransform.localScale;
            rectTransform.localScale = new Vector3(oldScale.x * 2f, oldScale.y * 2f, oldScale.z * 2f);
            switchImage.color = new Color(1, switchImage.color.g - 0.2f, switchImage.color.b - 0.2f);
            pokeballObj.SetActive(false);
            switchImage.enabled = true;
            textboxHandler.TextBoxPrompt("... into a switch!", new string[]{"Ok"}, o =>
            {
                isPokeballDone = true;
            });
        });
    }
    
    private IEnumerator WaitForSpaghet()
    {
        yield return new WaitForSeconds(2.4f);
        spaghetObj.SetActive(false);
        spaghetImage.enabled = true;
        yield return new WaitForSeconds(2f);
        isSpaghetDone = true;
    }

    private void Update()
    {
        if (isSpaghetDone && isPokeballDone && isBreakDone && isSwitchOffDone)
            OpenRatingPanel();
    }

    public void RateLevel(int rating)
    {
        scenarioRater.UploadScore(rating, "test_scenario");
        BackToMenu();
    }
    
    public void BackToMenu() => SceneManager.LoadScene("Menu");
}
