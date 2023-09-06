using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct KeyBinding
{
    public KeyCode keyCode;
    public Sprite sprite;
}

[CreateAssetMenu(fileName = "Binding", menuName = "ScriptableObjects/Binding")]
public class PictoBinding : ScriptableObject
{
    public List<KeyBinding> bindings = new List<KeyBinding>();
}
