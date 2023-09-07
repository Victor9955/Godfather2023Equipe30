using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using static UnityEngine.InputManagerEntry;

public class Card : MonoBehaviour
{
    [SerializeField] List<Key> keysRenderer;
    List<KeyBinding> keys = new List<KeyBinding>();
    [SerializeField] PictoBinding bind;
    [SerializeField] GameEventHandler gameEvents;

    public void Init()
    {
        gameEvents.Init(keys.Count);
        keys.Clear();
        keys.AddRange(gameEvents.keys);

        for (int i = 0; i < keysRenderer.Count - 1; i++)
        {
            keysRenderer[i].Init(keys[i]);
        }
    }
}
