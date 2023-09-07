using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimations : MonoBehaviour
{
    [SerializeField] GameEventHandler gameEvents;
    void Start()
    {
        gameEvents.WrongInput += WrongInput;
    }

    private void OnDestroy()
    {
        gameEvents.WrongInput -= WrongInput;
    }

    private void WrongInput()
    {
        transform.DOShakePosition(0.2f,0.5f);
    }
}
