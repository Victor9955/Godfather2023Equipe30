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

    public List<KeyBinding> GetRandomList(int amount)
    {
        List<KeyBinding> random = bindings.OrderBy(x => UnityEngine.Random.value).ToList();
        random.RemoveRange(0, 24 - amount);
        return random;
    }

    public List<KeyBinding> ResetList()
    {

    }

    public List<KeyBinding> GetNextList()
    {

    }
}
