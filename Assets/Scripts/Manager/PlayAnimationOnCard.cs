using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnCard : MonoBehaviour
{
    [SerializeField] GameEventHandler gamesEvents;
    [SerializeField] Sprite resetSprite;
    [SerializeField] Sprite firstFrame;
    [SerializeField] Sprite secondFrame;
    SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        gamesEvents.FXWinCard += OnWinCard;
    }

    [Button]
    void OnWinCard()
    {
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        sp.sprite = firstFrame;
        yield return new WaitForSeconds(0.3f);
        sp.sprite = secondFrame;
        yield return new WaitForSeconds(1.2f);
        sp.sprite = resetSprite;
    }

    private void OnDestroy()
    {
        gamesEvents.FXWinCard -= OnWinCard;
    }
}
