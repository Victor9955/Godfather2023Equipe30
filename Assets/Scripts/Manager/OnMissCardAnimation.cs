using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMissCardAnimation : MonoBehaviour
{
    [SerializeField] GameEventHandler gamesEvents;
    [SerializeField] Transform resetPos;
    [SerializeField] Transform losePos;
    Coroutine coroutine = null;

    private void Start()
    {
        gamesEvents.WrongInput += OnWrongCard;
    }

    [Button]
    void OnWrongCard()
    {
        if(coroutine == null)
        {
            coroutine = StartCoroutine(Anim());
        }
    }

    IEnumerator Anim()
    {
        transform.DOMove(losePos.position, 0.2f);
        yield return new WaitForSeconds(1.5f);
        transform.DOMove(resetPos.position, 0.2f);
        coroutine = null;
    }

    private void OnDestroy()
    {
        gamesEvents.WrongInput -= OnWrongCard;
    }
}
