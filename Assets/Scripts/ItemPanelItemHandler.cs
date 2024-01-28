using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanelItemHandler : MonoBehaviour
{
    public Image hoverImage;
    
    private bool mouseOver = true;
    
    private void Update()
    {
        hoverImage.color = new Color(hoverImage.color.r, hoverImage.color.g, hoverImage.color.b, mouseOver ? 1f : 0f);
        mouseOver = false;
    }

    private void OnMouseOver() => mouseOver = true;
}
