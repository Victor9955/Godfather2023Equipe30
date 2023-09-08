using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEngine.InputManagerEntry;


[CreateAssetMenu(fileName = "GameEvents", menuName = "ScriptableObjects/GameEvents")]
public class GameEventHandler : ScriptableObject
{
    public event Action InitCard;

    public event Action WrongInput;
    public event Action WinCard;

    public Sprite resetSprite;

    [SerializeField] PictoBinding bind;
    public List<KeyBinding> keys = new List<KeyBinding>();

    [Button]
    public void Test()
    {
        Init(5);
    }


    public void Init(int amount)
    {
        List<KeyBinding> random = bind.bindings.OrderBy(x => UnityEngine.Random.value).ToList();
        keys.Clear();
        for (int i = 0; i < amount; i++)
        {
            keys.Add(new KeyBinding());
            keys[i] = random[i];
        }
        InitCard?.Invoke();
    }

    public void WinCardInvoke()
    {
        WinCard?.Invoke();
    }

    public void WrongInputInvoke()
    {
        WrongInput?.Invoke();
    }
}
