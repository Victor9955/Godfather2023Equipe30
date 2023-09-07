using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    [SerializeField] GameEventHandler gameEvents;
    [SerializeField] GameObject[] showKeysGrid;


    List<KeyBinding> keys = new List<KeyBinding>();
    Queue<KeyBinding> testingKeys = new Queue<KeyBinding>();


    private void Start()
    {
        gameEvents.InitCard += OnInit;
    }

    void OnInit()
    {
        keys.Clear();
        keys.AddRange(gameEvents.keys);
        foreach (var item in keys)
        {
            testingKeys.Enqueue(item);
        }

        foreach (var item in showKeysGrid)
        {
            item.SetActive(false);
        }

        for (int i = 0; i < keys.Count; i++)
        {
            showKeysGrid[i].SetActive(true);
        }

        Begin();
    }

    IEnumerator WaitForKey()
    {
        while (testingKeys.Count > 0)
        {
            if (Input.anyKeyDown)
            {
                TestKey();
            }
            yield return null;
        }

        ResetSprites();
        foreach (var item in showKeysGrid)
        {
            item.SetActive(false);
        }
        gameEvents.WinCardInvoke();
        //Debug.Log("WinCard");
    }

    void TestKey()
    {
        if (Input.GetKeyDown(testingKeys.Peek().keyCode))
        {
            showKeysGrid[keys.IndexOf(testingKeys.Peek())].GetComponent<SpriteRenderer>().sprite = testingKeys.Peek().sprite;
            testingKeys.Dequeue();
            //Debug.Log("Good");
        }
        else
        {
            ResetSprites();
            testingKeys.Clear();
            foreach (var item in keys)
            {
                testingKeys.Enqueue(item);
            }
            gameEvents.WrongInputInvoke();
            //Debug.Log("Retry");
        }
    }

    void Begin()
    {
        StartCoroutine(WaitForKey());
    }

    void ResetSprites()
    {
        foreach (var item in showKeysGrid)
        {
            item.GetComponent<SpriteRenderer>().sprite = gameEvents.resetSprite;
        }
    }
}
