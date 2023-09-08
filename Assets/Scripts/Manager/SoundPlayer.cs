using System.Collections.Generic;
using System;
using UnityEngine;


[Serializable]
class MySound
{
    public AudioClip clip;
    public float volume;
}

public class SoundPlayer : MonoBehaviour
{
[SerializeField] GameEventHandler eventHandler;
[SerializeField] AudioSource listener;
[SerializeField] List<MySound> sounds;

void Start()
{
    eventHandler.InitCard += PlayOnInitCard;
    eventHandler.WrongInput += PlayOnWrongKey;
    eventHandler.FXWinCard += PlayOnRightKey;
    eventHandler.WinCard += PlayOnNextCard;
}

void OnDestroy()
{
    eventHandler.InitCard -= PlayOnInitCard;
    eventHandler.WrongInput -= PlayOnWrongKey;
    eventHandler.FXWinCard -= PlayOnRightKey;
    eventHandler.WinCard -= PlayOnNextCard;
}

void PlayOnInitCard()
{
    listener.clip = sounds[0].clip;
    listener.volume = sounds[0].volume;
    listener.Play();
}
void PlayOnWrongKey()
{
    listener.clip = sounds[1].clip;
    listener.volume = sounds[1].volume;
    listener.Play();
}
void PlayOnRightKey()
{
    listener.clip = sounds[2].clip;
    listener.volume = sounds[2].volume;
    listener.Play();
}
void PlayOnNextCard()
{
    listener.clip = sounds[3].clip;
    listener.volume = sounds[3].volume;
    listener.Play();
}
}