using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Key : MonoBehaviour
{
    SpriteRenderer spr;

    public void Init(KeyBinding initKey)
    {
        spr = GetComponent<SpriteRenderer>();
        spr.enabled = true;
        spr.sprite = initKey.sprite;
    }
}
