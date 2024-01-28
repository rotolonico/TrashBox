using System;
using UnityEngine;

public class SpriteObject : GenericObject
{
    public Sprite sprite;
    
    public SpriteObject(Vector2 position, Sprite sprite, Action<object> onClick, Action<object> onActive)
    {
        this.x = position.x;
        this.y = position.y;
        this.sprite = sprite;
    }
}
