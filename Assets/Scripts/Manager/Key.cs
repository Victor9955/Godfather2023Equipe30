using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Key : MonoBehaviour
{
    public KeyBinding key;
    SpriteRenderer spr;

    public void Init()
    {
        spr = GetComponent<SpriteRenderer>();
        Debug.Log(key.keyCode.ToString());
        spr.sprite = key.sprite;
        spr.enabled = false;
    }

    public void Show()
    {
        spr.enabled = true;
    }

    public void Hide() 
    { 
        spr.enabled = false;
    }
}
