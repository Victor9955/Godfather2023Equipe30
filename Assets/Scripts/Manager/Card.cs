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
        gameEvents.WinCard += Win;

        gameEvents.Init(keysRenderer.Count);
        keys.Clear();
        keys.AddRange(gameEvents.keys);

        //Debug.Log(keysRenderer.Count);

        for (int i = 0; i < keysRenderer.Count; i++)
        {
            keysRenderer[i].Init(keys[i]);
        }
    }

    private void Win()
    {
        CardSpawnerManager.instance.AddPoint();
        CardSpawnerManager.instance.RespawnCard();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        gameEvents.WinCard -= Win;
    }
}
