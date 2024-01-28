using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextboxHandler : MonoBehaviour
{
    public GameObject textbox;
    public TextMeshProUGUI text;
    
    public GameObject buttonsContainer;
    public GameObject buttonPrefab;
    
    public void TextBoxPrompt(string text, string[] options, Action<int> callback, bool isTextColorWhite = false)
    {
        textbox.SetActive(true);
        this.text.text = text;
        this.text.color = isTextColorWhite ? Color.white : Color.black;
        
        foreach (Transform b in buttonsContainer.transform) Destroy(b.gameObject);

        foreach (var o in options)
        {
            var newButton = Instantiate(buttonPrefab, transform.position, Quaternion.identity);
            newButton.gameObject.transform.SetParent(buttonsContainer.transform);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = o;
            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                textbox.SetActive(false);
                callback(Array.IndexOf(options, o));
            }); 
        }

    }
    
    public void ClosePanel() => gameObject.SetActive(false);
}
